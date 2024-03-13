namespace Flow.Contracts.Responses.PlannedExpense;

public sealed class MonthlyPlannedExpense
{
    public required string Name { get; init; }

    public required decimal Amount { get; init; }

    public required string Currency { get; init; }
}