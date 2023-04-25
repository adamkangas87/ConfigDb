using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Persistance.Constants;

namespace Persistance.Configurations
{
    public class ConfigItemConfiguration : AuditableConfiguration<ConfigItem>
    {
        public override void Configure(EntityTypeBuilder<ConfigItem> builder)
        {
            builder.ToTable("ConfigItems");
            builder.HasKey(r => r.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(DatabaseConstants.NameColumnLength);
            builder.HasOne(x=>x.Type).WithMany(x=>x.Items).HasForeignKey(x=>x.TypeId).OnDelete(DeleteBehavior.NoAction);
            ConfigureAudtiable(builder);
        }
    }
}
