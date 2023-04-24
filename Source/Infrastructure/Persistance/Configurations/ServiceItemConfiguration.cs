using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Persistance.Constants;

namespace Persistance.Configurations
{
    public class ServiceItemConfiguration : IEntityTypeConfiguration<ServiceItem>
    {
        public void Configure(EntityTypeBuilder<ServiceItem> builder)
        {
            builder.ToTable("ServiceItems");
            builder.HasKey(r => r.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(DatabaseConstants.NameColumnLength);
        }
    }
}
