﻿using Flow.Domain.Currencies;

namespace Flow.Infrastructure.Persistence.Configurations;

internal sealed class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
{
    public void Configure(EntityTypeBuilder<Currency> builder)
    {
        builder.HasIndex(x => x.Code).IsUnique();
        builder.Property(x => x.Code)
            .HasConversion(x => x.Value, x => CurrencyCode.Create(x).Value)
            .HasMaxLength(CurrencyCode.Length);
    }
}