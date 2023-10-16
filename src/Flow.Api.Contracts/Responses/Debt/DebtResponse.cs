using Flow.Api.Contracts.Responses.Currency;

namespace Flow.Api.Contracts.Responses.Debt;

public sealed record DebtResponse
{
    public Guid Id { get; init; }

    public string Name { get; init; }

    public decimal Amount { get; init; }

    public CurrencyShortResponse Currency { get; init; }
}