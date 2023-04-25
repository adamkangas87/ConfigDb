using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Persistance.Constants;

namespace Persistance.Configurations
{
    public class ContactConfiguration : AuditableConfiguration<Contact>
    {
        public override void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts");
            builder.HasKey(r => r.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(DatabaseConstants.NameColumnLength);
            builder.HasOne(x=>x.Provider).WithMany().HasForeignKey(x=>x.ProviderId).OnDelete(DeleteBehavior.NoAction);
            ConfigureAudtiable(builder);
        }
    }
}
