using Flow.DataAccess.Constants;
using Flow.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flow.DataAccess.Configurations;

internal sealed class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
{
    public void Configure(EntityTypeBuilder<Currency> builder)
    {
        builder.HasIndex(x => x.Code).IsUnique();
        builder.Property(x => x.Code).HasMaxLength(DatabaseConstants.Length8);
        builder.Property(x => x.Name).HasMaxLength(DatabaseConstants.Length64);
        builder.Property(x => x.IsActive).HasDefaultValue(false);
    }
}
