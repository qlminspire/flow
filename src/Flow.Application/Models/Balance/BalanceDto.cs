using Flow.Application.Models.Currency;

namespace Flow.Application.Models.Balance;

public sealed class BalanceDto
{
    public decimal Amount { get; init; }

    public CurrencyDto Currency { get; init; }
}
