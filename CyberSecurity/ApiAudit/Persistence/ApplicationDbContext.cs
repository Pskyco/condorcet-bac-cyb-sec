using ApiAudit.Entities;
using ApiAudit.Entities.Common;
using ApiAudit.Extensions;
using ApiAudit.Helpers;
using ApiAudit.Services;
using Audit.Core;
using Audit.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace ApiAudit.Persistence;

public class ApplicationDbContext : AuditDbContext
{
    private readonly IUserService _userService;
    private readonly AuditTrailHelper _auditTrailHelper;
    
    public DbSet<Person> Persons { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IUserService userService, AuditTrailHelper auditTrailHelper) : base(options)
    {
        _userService = userService;
        _auditTrailHelper = auditTrailHelper;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // builder.Entity<Person>().ToTable("Persons");
        builder.Entity<AuditTrail>().ToTable("AuditTrail");
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        ChangeTracker.AuditEntities(_userService);
        // use one of these
        _auditTrailHelper.SetAuditableProperties(this);
        return await base.SaveChangesAsync(cancellationToken);
    }

    public override void OnScopeCreated(IAuditScope auditScope)
    {
        base.OnScopeCreated(auditScope);
        auditScope.SetCustomField(nameof(Auditable.LastUpdaterUserId), _userService.GetCurrentUserId());
    }
}