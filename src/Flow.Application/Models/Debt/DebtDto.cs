using Flow.Application.Models.Currency;

namespace Flow.Application.Models.Debt;

public sealed class DebtDto
{
    public Guid Id { get; init; }

    public string Name { get; init; }

    public decimal Amount { get; init; }

    public CurrencyDto Currency { get; init; }
}
