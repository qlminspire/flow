using Flow.Domain.PlannedExpenses;
using Flow.Domain.Shared;

namespace Flow.Infrastructure.Persistence.Configurations;

internal sealed class PlannedExpenseConfiguration : IEntityTypeConfiguration<PlannedExpense>
{
    public void Configure(EntityTypeBuilder<PlannedExpense> builder)
    {
        builder.Property(x => x.Name)
            .HasConversion(x => x.Value, x => PlannedExpenseName.Create(x).Value)
            .HasMaxLength(PlannedExpenseName.MaxLength);

        builder.Property(x => x.Amount)
            .HasConversion(x => x.Value, x => Money.Create(x).Value);
    }
}