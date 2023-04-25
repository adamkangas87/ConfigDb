using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistance.Constants;

namespace Persistance.Configurations
{
    public abstract class AuditableConfiguration<T> : IEntityTypeConfiguration<T>
        where T : Auditable
    {
        public abstract void Configure(EntityTypeBuilder<T> builder);

        public void ConfigureAudtiable(EntityTypeBuilder<T> builder)
        {

            builder.Property(t => t.DateCreated).HasColumnType(DatabaseConstants.DateTimeOffsetColumnType);
            builder.Property(t => t.DateModified).HasColumnType(DatabaseConstants.DateTimeOffsetColumnType);
            builder.Property(t => t.RowVersion).IsRowVersion().IsRequired().IsConcurrencyToken();
        }
    }
}
