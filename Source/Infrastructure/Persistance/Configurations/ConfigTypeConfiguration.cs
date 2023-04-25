using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Persistance.Constants;

namespace Persistance.Configurations
{
    public class ConfigTypeConfiguration : AuditableConfiguration<ConfigType>
    {
        public override void Configure(EntityTypeBuilder<ConfigType> builder)
        {
            builder.ToTable("ConfigTypes");
            builder.HasKey(r => r.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(DatabaseConstants.NameColumnLength);
            builder.HasMany(x=>x.Items).WithOne(x=>x.Type).HasForeignKey(x=>x.TypeId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Provider).WithMany(x => x.Types).HasForeignKey(x => x.ProviderId).OnDelete(DeleteBehavior.NoAction);
            ConfigureAudtiable(builder);
        }
    }
}
