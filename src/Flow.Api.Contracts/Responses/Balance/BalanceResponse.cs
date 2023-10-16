using Flow.Api.Contracts.Responses.Currency;

namespace Flow.Api.Contracts.Responses.Balance;

public sealed record BalanceResponse(decimal Amount, CurrencyShortResponse Currency);