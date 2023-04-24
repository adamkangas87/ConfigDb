
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Configurations;
using Persistance.Extensions;

namespace Persistance.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<ConfigItem> ConfigItems { get; set; }
        public DbSet<ConfigType> ConfigTypes { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<ServiceItem> ServiceItems { get; set; }
        public DbSet<ServiceLevel> ServiceLevels { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Data");
            modelBuilder.ApplyConfiguration(new ConfigItemConfiguration());
            modelBuilder.ApplyConfiguration(new ConfigTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new LocationConfiguration());
            modelBuilder.ApplyConfiguration(new ProviderConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceItemConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceLevelConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceTypeConfiguration());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeTracker.Entries<Auditable>().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified).UpdateAuditableDates();
            ChangeTracker.DetectChanges();
            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}

