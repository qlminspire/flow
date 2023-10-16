namespace Flow.Api.Contracts.Responses.AccountOperation;

public sealed record AccountOperationResponse
{
    public Guid Id { get; init; }

    public Guid FromAccountId { get; init; }

    public Guid ToAccountId { get; init; }

    public decimal Amount { get; init; }
}
