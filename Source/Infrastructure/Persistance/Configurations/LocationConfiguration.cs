﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Persistance.Constants;

namespace Persistance.Configurations
{
    public class LocationConfiguration : AuditableConfiguration<Location>
    {
        public override void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("Locations");
            builder.HasKey(r => r.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(DatabaseConstants.NameColumnLength);
            ConfigureAudtiable(builder);
        }
    }
}
