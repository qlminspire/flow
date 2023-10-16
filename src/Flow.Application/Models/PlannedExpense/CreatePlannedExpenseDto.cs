namespace Flow.Application.Models.PlannedExpense;

public sealed class CreatePlannedExpenseDto
{
    public string Name { get; init; }

    public decimal Amount { get; init; }

    public Guid CurrencyId { get; init; }
}
