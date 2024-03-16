using Flow.Domain.Currencies;
using Flow.Domain.Debts;
using Flow.Domain.Users;

namespace Flow.Infrastructure.Persistence.Configurations;

internal sealed class DebtConfiguration : IEntityTypeConfiguration<Debt>
{
    public void Configure(EntityTypeBuilder<Debt> builder)
    {
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new DebtId(x));

        builder.Property(x => x.Name)
            .HasConversion(x => x.Value, x => DebtName.Create(x).Value)
            .HasMaxLength(DebtName.MaxLength);

        builder.Property(x => x.Amount)
            .HasConversion(x => x.Value, x => Money.Create(x).Value);

        builder.Property(x => x.CurrencyId)
            .HasConversion(x => x.Value, x => new CurrencyId(x));

        builder.Property(x => x.UserId)
            .HasConversion(x => x.Value, x => new UserId(x));
    }
}