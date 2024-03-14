namespace Flow.Contracts.Responses.Balance;

public sealed record BalanceResponse
{
    public required decimal Amount { get; init; }

    public required string Currency { get; init; }
}