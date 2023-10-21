namespace Flow.Contracts.Responses.PlannedExpense;

public sealed class MonthlyPlannedExpense
{
    public required decimal Amount { get; init; }

    public required string Currency { get; init; }
}
