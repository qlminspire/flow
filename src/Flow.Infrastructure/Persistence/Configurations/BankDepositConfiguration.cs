using Flow.Domain.Accounts;
using Flow.Domain.BankDeposits;
using Flow.Domain.Currencies;
using Flow.Domain.UserCategories;
using Flow.Domain.Users;

namespace Flow.Infrastructure.Persistence.Configurations;

internal sealed class BankDepositConfiguration : IEntityTypeConfiguration<BankDeposit>
{
    public void Configure(EntityTypeBuilder<BankDeposit> builder)
    {
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new BankDepositId(x));

        builder.Property(x => x.Amount)
            .HasConversion(x => x.Value, x => Money.Create(x).Value);

        builder.Property(x => x.CurrencyId)
            .HasConversion(x => x.Value, x => new CurrencyId(x));

        builder.Property(x => x.UserId)
            .HasConversion(x => x.Value, x => new UserId(x));

        builder.Property(x => x.RefundAccountId)
            .HasConversion(x => x.Value, x => new AccountId(x));

        builder.Property(x => x.CategoryId)
            .HasConversion(x => x.Value, x => new UserCategoryId(x));
    }
}