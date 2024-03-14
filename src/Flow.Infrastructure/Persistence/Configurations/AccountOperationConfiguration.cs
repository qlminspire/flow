using Flow.Domain.AccountOperations;

namespace Flow.Infrastructure.Persistence.Configurations;

internal sealed class AccountOperationConfiguration : IEntityTypeConfiguration<AccountOperation>
{
    public void Configure(EntityTypeBuilder<AccountOperation> builder)
    {
        builder.Property(x => x.Amount)
            .HasConversion(x => x.Value, x => Money.Create(x).Value);
    }
}