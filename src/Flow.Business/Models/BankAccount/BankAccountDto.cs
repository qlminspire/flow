using Flow.Business.Models.Bank;
using Flow.Business.Models.Currency;

namespace Flow.Business.Models.BankAccount;

public sealed class BankAccountDto
{
    public Guid Id { get; set; }

    public string Iban { get; set; }

    public BankDto Bank { get; set; }

    public decimal Amount { get; set; }

    public CurrencyDto Currency { get; set; }
}
