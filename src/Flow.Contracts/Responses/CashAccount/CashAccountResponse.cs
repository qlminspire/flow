namespace Flow.Contracts.Responses.CashAccount;

public sealed record CashAccountResponse
{
    public required Guid Id { get; init; }

    public required string Name { get; init; }

    public required decimal Balance { get; init; }

    public required string Currency { get; init; }

    public string? Category { get; init; }
}