namespace Flow.Api.Contracts.Requests.PlannedExpense;

public sealed record UpdatePlannedExpenseRequest
{
    public string? Name { get; init; }

    public decimal Amount { get; init; }

    public Guid CurrencyId { get; init; }
}