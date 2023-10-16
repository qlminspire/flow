namespace Flow.Application.Models.PlannedExpense;

public sealed class UpdatePlannedExpenseDto
{
    public string Name { get; init; }

    public decimal Amount { get; init; }

    public Guid CurrencyId { get; init; }
}