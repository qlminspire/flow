using Flow.Application.Models.Currency;

namespace Flow.Application.Models.CashAccount;

public sealed class CashAccountDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public decimal Amount { get; set; }

    public CurrencyDto Currency { get; set; }
}
