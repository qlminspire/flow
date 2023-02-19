﻿using Flow.DataAccess.Constants;
using Flow.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flow.DataAccess.Configurations;

internal sealed class BankConfiguration : IEntityTypeConfiguration<Bank>
{
    public void Configure(EntityTypeBuilder<Bank> builder)
    {
        builder.HasIndex(x => x.Name).IsUnique();
        builder.Property(x => x.Name).HasMaxLength(DatabaseConstants.Length64);
        builder.Property(x => x.IsActive).HasDefaultValue(false);
    }
}
