using Flow.Domain.Accounts;

namespace Flow.Domain.AccountOperations;

public sealed class AccountOperation : Entity, IAuditable
{
    public decimal Amount { get; set; }

    public Guid FromAccountId { get; set; }

    public Account? FromAccount { get; set; }

    public Guid ToAccountId { get; set; }

    public Account? ToAccount { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }
}