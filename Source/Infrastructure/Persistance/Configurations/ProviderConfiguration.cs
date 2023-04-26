using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Persistance.Constants;

namespace Persistance.Configurations
{
    public class ProviderConfiguration : AuditableConfiguration<Provider>
    {
        public override void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder.ToTable("Providers");
            builder.HasKey(r => r.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(DatabaseConstants.NameColumnLength);
            builder.HasMany(x => x.Types).WithOne(x => x.Provider).HasForeignKey(x => x.ProviderId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Contacts).WithOne(x => x.Provider).HasForeignKey(x => x.ProviderId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x=>x.Locations).WithOne(x=>x.Provider).HasForeignKey(x=>x.ProviderId).OnDelete(DeleteBehavior.Cascade);
            ConfigureAudtiable(builder);
        }
    }
}
