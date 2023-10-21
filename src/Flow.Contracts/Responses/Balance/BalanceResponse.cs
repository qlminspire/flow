using Flow.Contracts.Responses.Currency;

namespace Flow.Contracts.Responses.Balance;

public sealed record BalanceResponse
{
    public required decimal Amount { get; init; }
    
    public required CurrencyShortResponse Currency { get; init; }
}