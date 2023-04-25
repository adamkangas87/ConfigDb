using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Persistance.Constants;

namespace Persistance.Configurations
{
    public class ServiceTypeConfiguration : AuditableConfiguration<ServiceType>
    {
        public override void Configure(EntityTypeBuilder<ServiceType> builder)
        {
            builder.ToTable("ServiceTypes");
            builder.HasKey(r => r.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(DatabaseConstants.NameColumnLength);
            builder.HasMany(x=>x.Items).WithOne(x=>x.Type).HasForeignKey(x=>x.TypeId).OnDelete(DeleteBehavior.Restrict);
            ConfigureAudtiable(builder);
        }
    }
}
