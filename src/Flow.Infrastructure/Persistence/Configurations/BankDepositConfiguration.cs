using Flow.Domain.BankDeposits;

namespace Flow.Infrastructure.Persistence.Configurations;

internal sealed class BankDepositConfiguration : IEntityTypeConfiguration<BankDeposit>
{
    public void Configure(EntityTypeBuilder<BankDeposit> builder)
    {
        builder.Property(x => x.Amount)
            .HasConversion(x => x.Value, x => Money.Create(x).Value);
    }
}