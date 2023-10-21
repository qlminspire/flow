using Flow.Api.Contracts.Responses.Currency;

namespace Flow.Api.Contracts.Responses.Debt;

public sealed record DebtResponse
{
    public required Guid Id { get; init; }

    public required string Name { get; init; }

    public required decimal Amount { get; init; }

    public required CurrencyShortResponse Currency { get; init; }
}