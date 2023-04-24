using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Persistance.Constants;

namespace Persistance.Configurations
{
    public class ProviderConfiguration : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder.ToTable("Providers");
            builder.HasKey(r => r.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(DatabaseConstants.NameColumnLength);
            builder.HasMany(x => x.ConfigTypes).WithOne(x => x.Provider).HasForeignKey(x => x.ProviderId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.Contacts).WithOne(x => x.Provider).HasForeignKey(x => x.ProviderId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x=>x.Location).WithOne(x=>x.Provider).HasForeignKey<Provider>(x=>x.LocationId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
