namespace Flow.Application.Models.AccountOperation;

public sealed class AccountOperationDto
{
    public required Guid Id { get; init; }

    public required Guid FromAccountId { get; init; }

    public required Guid ToAccountId { get; init; }

    public required decimal Amount { get; init; }
}