namespace Flow.Application.Models.BankAccount;

public sealed record CreateBankAccountDto
{
    public string? Name { get; init; }

    public string? Iban { get; init; }

    public Guid BankId { get; init; }

    public decimal Amount { get; init; }

    public string? Currency { get; init; }

    public Guid? CategoryId { get; init; }
}