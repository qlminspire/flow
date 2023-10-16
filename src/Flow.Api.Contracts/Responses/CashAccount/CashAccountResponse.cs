using Flow.Api.Contracts.Responses.Currency;

namespace Flow.Api.Contracts.Responses.CashAccount;

public sealed record CashAccountResponse
{
    public Guid Id { get; init; }

    public string Name { get; init; }

    public decimal Amount { get; init; }

    public CurrencyShortResponse Currency { get; init; }
}
