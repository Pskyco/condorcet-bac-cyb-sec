using ApiAudit.Entities.Common;
using ApiAudit.Persistence;
using ApiAudit.Services;
using Microsoft.EntityFrameworkCore;

namespace ApiAudit.Helpers;

public class AuditTrailHelper
{
    private readonly IUserService _userService;

    public AuditTrailHelper(IUserService userService)
    {
        _userService = userService;
    }

    public void SetAuditableProperties(ApplicationDbContext dbContext)
    {
        var entries = dbContext.ChangeTracker.Entries().Where(z =>
            (z.State == EntityState.Added || z.State == EntityState.Modified) && z.Entity is Auditable);

        var now = DateTime.Now;
        var currentUserId = _userService.GetCurrentUserId();

        foreach (var entry in entries)
        {
            var auditable = (IAuditable)entry.Entity;
            
            if (entry.State == EntityState.Added)
            {
                auditable.CreationDateTime = now;
                auditable.CreationUserId = currentUserId;
            }
            else
            {
                auditable.LastUpdateDateTime = now;
                auditable.LastUpdaterUserId = currentUserId;
            }
        }
    }
}