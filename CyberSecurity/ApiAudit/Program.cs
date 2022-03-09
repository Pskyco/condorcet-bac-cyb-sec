using ApiAudit.Entities;
using ApiAudit.Entities.Common;
using ApiAudit.Helpers;
using ApiAudit.Persistence;
using ApiAudit.Services;
using Audit.Core;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
WebApplication app;

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

try
{
    ConfigureServices();
    app = builder.Build();
    MigrateDatabase();
    ConfigurePipeline();
    app.Services.GetRequiredService<ILogger<Program>>().LogInformation("App configured successfully");
    app.Run();
}
catch(Exception e)
{
    Log.Fatal(e, "App terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}

void ConfigureServices()
{
    // Add services to the container.
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddDbContext<ApplicationDbContext>(x =>
        x.UseSqlServer(builder.Configuration.GetConnectionString("ApiAudit")));
    builder.Services.AddSingleton<IUserService, UserService>();
    builder.Services.AddScoped<AuditTrailHelper>();
    ConfigureAudit();
}

void ConfigureAudit()
{
    Configuration.Setup()
        .UseEntityFramework(options => options
            .AuditTypeMapper(t => typeof(AuditTrail))
            .AuditEntityAction<AuditTrail>((ev, entry, auditTrailEntity) =>
            {
                auditTrailEntity.EntityType = entry.EntityType.Name;
                auditTrailEntity.AuditDateTime = DateTime.Now;
                auditTrailEntity.AuditObjectId = Guid.Parse(entry.PrimaryKey.First().Value.ToString());
                auditTrailEntity.AuditData = entry.ToJson();
                auditTrailEntity.ActionType = entry.Action;
                auditTrailEntity.AuditUserId = Guid.Parse(ev.CustomFields[nameof(Auditable.LastUpdaterUserId)]?.ToString());
            })
            .IgnoreMatchedProperties());
}

void MigrateDatabase()
{
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

void ConfigurePipeline()
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}