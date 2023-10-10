namespace Flow.Domain.Entities;

public sealed class AccountOperation : BaseEntity, IHasDate
{
    public AccountOperationType OperationType { get; set; }

    public decimal Price { get; set; }

    public Guid AccountId { get; set; }

    public Account? Account { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }
}
