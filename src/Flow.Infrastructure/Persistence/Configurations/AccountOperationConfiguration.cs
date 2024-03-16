using Flow.Domain.AccountOperations;
using Flow.Domain.Accounts;

namespace Flow.Infrastructure.Persistence.Configurations;

internal sealed class AccountOperationConfiguration : IEntityTypeConfiguration<AccountOperation>
{
    public void Configure(EntityTypeBuilder<AccountOperation> builder)
    {
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new AccountOperationId(x));

        builder.Property(x => x.FromAccountId)
            .HasConversion(x => x.Value, x => new AccountId(x));

        builder.Property(x => x.ToAccountId)
            .HasConversion(x => x.Value, x => new AccountId(x));

        builder.Property(x => x.Amount)
            .HasConversion(x => x.Value, x => Money.Create(x).Value);
    }
}