namespace Flow.Contracts.Responses.Debt;

public sealed record DebtResponse
{
    public required Guid Id { get; init; }

    public required string Name { get; init; }

    public required decimal Amount { get; init; }

    public required string Currency { get; init; }
}