using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MyApi.OperationFilters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://localhost:5001";
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateAudience = false,
        };
    });

builder.Services.AddAuthorization(options => options.AddPolicy("MyApiScope", policy =>
{
    policy.RequireAuthenticatedUser();
    policy.RequireClaim("scope", "myApi");
}));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo() { Title = "MyApi", Version = "v1" });

    var securitySchema = new OpenApiSecurityScheme()
    {
        Description = "JWT Bearer",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        Reference = new OpenApiReference()
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };

    options.AddSecurityDefinition("Bearer", securitySchema);

    options.OperationFilter<AuthorizeOperationFilter>();

    //var securityRequirements = new OpenApiSecurityRequirement()
    //{
    //    { securitySchema, new[] { "Bearer" } }
    //};

    //options.AddSecurityRequirement(securityRequirements);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers().RequireAuthorization("MyApiScope");

app.Run();
