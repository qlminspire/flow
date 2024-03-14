namespace Flow.Application.Models.PlannedExpense;

public sealed class MonthlyPlannedExpenseDto
{
    public required decimal Amount { get; init; }

    public required string Currency { get; init; }
}