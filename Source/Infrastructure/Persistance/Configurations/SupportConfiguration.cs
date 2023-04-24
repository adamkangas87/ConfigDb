using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Persistance.Constants;

namespace Persistance.Configurations
{
    public class SupportConfiguration : IEntityTypeConfiguration<Support>
    {
        public void Configure(EntityTypeBuilder<Support> builder)
        {
            builder.ToTable("Supports");
            builder.HasKey(r => r.Id);
            builder.Property(x => x.Portal).IsRequired().HasMaxLength(DatabaseConstants.NameColumnLength);
        }
    }
}
