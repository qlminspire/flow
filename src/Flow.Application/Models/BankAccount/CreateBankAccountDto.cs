namespace Flow.Application.Models.BankAccount;

public sealed record CreateBankAccountDto
{
    public string Iban { get; init; }

    public Guid BankId { get; init; }

    public Guid CurrencyId { get; init; }

    public decimal Amount { get; init; }
}
