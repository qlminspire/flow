namespace Flow.Contracts.Requests.Debt;

public sealed record CreateDebtRequest
{
    public string? Name { get; init; }

    public decimal Amount { get; init; }

    public string? Currency { get; init; }
}