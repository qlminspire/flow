namespace Flow.Application.Models.BankAccount;

public sealed class BankAccountDto
{
    public Guid Id { get; set; }

    public string Iban { get; set; }

    public Guid BankId { get; set; }

    public decimal Amount { get; set; }

    public Guid CurrencyId { get; set; }
}
