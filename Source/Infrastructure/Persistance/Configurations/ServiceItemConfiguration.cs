using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Persistance.Constants;
using System.Security.Cryptography.X509Certificates;

namespace Persistance.Configurations
{
    public class ServiceItemConfiguration : AuditableConfiguration<ServiceItem>
    {
        public override void Configure(EntityTypeBuilder<ServiceItem> builder)
        {
            builder.ToTable("ServiceItems");
            builder.HasKey(r => r.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(DatabaseConstants.NameColumnLength);
            builder.HasOne(x => x.Type).WithMany(x => x.Items).HasForeignKey(x => x.TypeId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Provider).WithMany(x => x.Items).HasForeignKey(x => x.ProviderId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Location).WithOne(x => x.ServiceItem).HasForeignKey<ServiceItem>(x => x.LocationId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.ServiceLevel).WithMany(x => x.Items).HasForeignKey(x => x.ServiceLevelId).OnDelete(DeleteBehavior.NoAction);
            ConfigureAudtiable(builder);
        }
    }
}
