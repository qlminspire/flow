using Flow.Domain.Accounts;
using Flow.Domain.Income;

namespace Flow.Infrastructure.Persistence.Configurations;

internal sealed class UserIncomeConfiguration : IEntityTypeConfiguration<UserIncome>
{
    public void Configure(EntityTypeBuilder<UserIncome> builder)
    {
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new UserIncomeId(x));

        builder.Property(x => x.Amount)
            .HasConversion(x => x.Value, x => Money.Create(x).Value);

        builder.Property(x => x.AccountId)
            .HasConversion(x => x.Value, x => new AccountId(x));

        builder.HasOne(x => x.Account)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);
    }
}