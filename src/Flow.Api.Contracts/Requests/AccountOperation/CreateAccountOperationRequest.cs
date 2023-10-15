namespace Flow.Api.Contracts.Requests.AccountOperation;

public sealed class CreateAccountOperationRequest
{
    public Guid FromAccountId { get; init; }

    public Guid ToAccountId { get; init; }

    public decimal Amount { get; init; }
}
