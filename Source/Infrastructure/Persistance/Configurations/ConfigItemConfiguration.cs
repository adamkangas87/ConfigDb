using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Persistance.Constants;

namespace Persistance.Configurations
{
    public class ConfigItemConfiguration : IEntityTypeConfiguration<ConfigItem>
    {
        public void Configure(EntityTypeBuilder<ConfigItem> builder)
        {
            builder.ToTable("ConfigItems");
            builder.HasKey(r => r.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(DatabaseConstants.NameColumnLength);
            builder.HasOne(x=>x.ConfigType).WithMany(x=>x.ConfigItems).HasForeignKey(x=>x.ConfigTypeId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
