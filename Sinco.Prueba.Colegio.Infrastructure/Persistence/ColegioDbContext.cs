using Microsoft.EntityFrameworkCore;
using Sinco.Prueba.Colegio.Domain.Common;

namespace Sinco.Prueba.Colegio.Infrastructure.Persistence
{
    public class ColegioDbContext : DbContext
    {
        public ColegioDbContext(DbContextOptions<ColegioDbContext> options) : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<Entity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.Now;
                        entry.Entity.CreatedBy = "system";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastUpdatedAt = DateTime.Now;
                        entry.Entity.LastUpdatedBy = "system";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
