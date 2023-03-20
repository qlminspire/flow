using Flow.Domain.Entities;
using Flow.Infrastructure.Persistance.Constants;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flow.Infrastructure.Persistance.Configurations;

internal sealed class CashAccountConfiguration : IEntityTypeConfiguration<CashAccount>
{
    public void Configure(EntityTypeBuilder<CashAccount> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(DatabaseConstants.Length64);
    }
}
