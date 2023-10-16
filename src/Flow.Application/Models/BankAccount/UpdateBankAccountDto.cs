namespace Flow.Application.Models.BankAccount;

public sealed record UpdateBankAccountDto
{
    public decimal Amount { get; init; }

    public Guid CurrencyId { get; init; }

    public Guid? CategoryId { get; init; }
}
