using Flow.Domain.Currencies;
using Flow.Domain.PlannedExpenses;
using Flow.Domain.Users;

namespace Flow.Infrastructure.Persistence.Configurations;

internal sealed class PlannedExpenseConfiguration : IEntityTypeConfiguration<PlannedExpense>
{
    public void Configure(EntityTypeBuilder<PlannedExpense> builder)
    {
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new PlannedExpenseId(x));

        builder.Property(x => x.Name)
            .HasConversion(x => x.Value, x => PlannedExpenseName.Create(x).Value)
            .HasMaxLength(PlannedExpenseName.MaxLength);

        builder.Property(x => x.Amount)
            .HasConversion(x => x.Value, x => Money.Create(x).Value);

        builder.Property(x => x.UserId)
            .HasConversion(x => x.Value, x => new UserId(x));

        builder.Property(x => x.CurrencyId)
            .HasConversion(x => x.Value, x => new CurrencyId(x));
    }
}