namespace Flow.Api.Contracts.Requests.Debt;

public sealed record CreateDebtRequest
{
    public string? Name { get; init; }

    public decimal Amount { get; init; }

    public Guid CurrencyId { get; init; }
}
