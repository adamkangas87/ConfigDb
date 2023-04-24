using Domain.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Extensions
{
    public static class ContextExtensions
    {
        public static void UpdateAuditableDates(this IEnumerable<EntityEntry<Auditable>> changes)
        {
            foreach (var change in changes)
            {
                change.Entity.DateModified = DateTimeOffset.Now;
                if (change.State == EntityState.Added)
                {
                    change.Entity.DateCreated = DateTimeOffset.Now;
                }
            }
        }
    }
}
