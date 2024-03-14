using Flow.Domain.Accounts;

namespace Flow.Infrastructure.Persistence.Configurations;

internal sealed class CashAccountConfiguration : IEntityTypeConfiguration<CashAccount>
{
    public void Configure(EntityTypeBuilder<CashAccount> builder)
    {
    }
}