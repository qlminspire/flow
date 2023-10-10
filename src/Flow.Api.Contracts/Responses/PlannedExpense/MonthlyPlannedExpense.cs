namespace Flow.Api.Contracts.Responses.PlannedExpense;

public sealed class MonthlyPlannedExpense
{
    public decimal Amount { get; init; }

    public string Currency { get; init; }
}
