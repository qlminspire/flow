namespace Flow.Contracts.Requests.PlannedExpense;

public sealed record CreatePlannedExpenseRequest
{
    public string? Name { get; init; }

    public decimal Amount { get; init; }

    public string? Currency { get; init; }
}