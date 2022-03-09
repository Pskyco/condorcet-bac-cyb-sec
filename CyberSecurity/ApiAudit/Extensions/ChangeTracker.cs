using ApiAudit.Entities.Common;
using ApiAudit.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ApiAudit.Extensions;

public static class ChangeTrackerExtensions
{
    public static void AuditEntities(this ChangeTracker tracker, IUserService userService)
    {
        var currentUserId = userService.GetCurrentUserId();
        foreach (var trackedEntry in tracker.Entries<Auditable>())
        {
            switch (trackedEntry.State)
            {
                case EntityState.Modified:
                    trackedEntry.Entity.Update(currentUserId);
                    break;
                case EntityState.Added:
                    trackedEntry.Entity.Insert(currentUserId);
                    break;
            }
        }
    }
}