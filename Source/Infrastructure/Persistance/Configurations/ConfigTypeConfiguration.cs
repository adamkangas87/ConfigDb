using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Persistance.Constants;

namespace Persistance.Configurations
{
    public class ConfigTypeConfiguration : IEntityTypeConfiguration<ConfigType>
    {
        public void Configure(EntityTypeBuilder<ConfigType> builder)
        {
            builder.ToTable("ConfigTypes");
            builder.HasKey(r => r.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(DatabaseConstants.NameColumnLength);
            builder.HasMany(x=>x.ConfigItems).WithOne(x=>x.ConfigType).HasForeignKey(x=>x.ConfigTypeId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Provider).WithMany(x => x.ConfigTypes).HasForeignKey(x => x.ProviderId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
