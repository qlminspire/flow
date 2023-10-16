namespace Flow.Application.Models.PlannedExpense;

public sealed class MonthlyPlannedExpenseDto
{
    public decimal Amount { get; init; }

    public string Currency { get; init; }
}