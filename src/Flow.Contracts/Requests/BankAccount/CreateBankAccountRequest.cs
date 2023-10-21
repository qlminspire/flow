namespace Flow.Contracts.Requests.BankAccount;

public sealed record CreateBankAccountRequest
{
    public string? Iban { get; init; }

    public Guid BankId { get; init; }

    public Guid CurrencyId { get; init; }

    public decimal Amount { get; init; }

    public Guid? CategoryId { get; init; }
}