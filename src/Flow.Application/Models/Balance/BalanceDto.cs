namespace Flow.Application.Models.Balance;

public sealed class BalanceDto
{
    public required decimal Amount { get; init; }

    public required string Currency { get; init; }
}