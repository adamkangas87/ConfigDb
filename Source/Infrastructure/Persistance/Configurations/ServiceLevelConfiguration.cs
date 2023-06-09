﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Persistance.Constants;

namespace Persistance.Configurations
{
    public class ServiceLevelConfiguration : AuditableConfiguration<ServiceLevel>
    {
        public override void Configure(EntityTypeBuilder<ServiceLevel> builder)
        {
            builder.ToTable("ServiceLevels");
            builder.HasKey(r => r.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(DatabaseConstants.NameColumnLength);
            builder.HasMany(x => x.Items).WithOne(x => x.ServiceLevel).HasForeignKey(x => x.ServiceLevelId).OnDelete(DeleteBehavior.Restrict);
            ConfigureAudtiable(builder);
        }
    }
}
