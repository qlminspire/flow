namespace Flow.Contracts.Requests.AccountOperation;

public sealed record CreateAccountOperationRequest
{
    public Guid FromAccountId { get; init; }

    public Guid ToAccountId { get; init; }

    public decimal Amount { get; init; }
}
