namespace Flow.Application.Models.CashAccount;

public sealed record CreateCashAccountDto
{
    public string? Name { get; init; }

    public decimal Amount { get; init; }

    public string? Currency { get; init; }

    public Guid? CategoryId { get; init; }
}