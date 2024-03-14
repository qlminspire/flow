namespace Flow.Contracts.Requests.BankAccount;

public sealed record CreateBankAccountRequest
{
    public string? Name { get; init; }

    public string? Iban { get; init; }

    public Guid BankId { get; init; }

    public decimal Amount { get; init; }

    public string? Currency { get; init; }

    public Guid? CategoryId { get; init; }
}