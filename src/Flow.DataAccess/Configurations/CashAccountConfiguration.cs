using Flow.DataAccess.Constants;
using Flow.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flow.DataAccess.Configurations;

internal sealed class CashAccountConfiguration : IEntityTypeConfiguration<CashAccount>
{
    public void Configure(EntityTypeBuilder<CashAccount> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(DatabaseConstants.Length64);
    }
}
