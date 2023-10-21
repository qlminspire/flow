namespace Flow.Contracts.Requests.CashAccount;

public sealed record CreateCashAccountRequest
{
    public string? Name { get; init; }

    public decimal Amount { get; init; }

    public Guid CurrencyId { get; init; }

    public Guid? CategoryId { get; init; }
}