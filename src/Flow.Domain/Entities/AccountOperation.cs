namespace Flow.Domain.Entities;

public sealed class AccountOperation : BaseEntity<Guid>, IHasDate
{
    public AccountOperationType OperationType { get; set; }

    public decimal Price { get; set; }

    public Guid AccountId { get; set; }

    public Account? Account { get; set; }

    public DateTimeOffset? CreateDate { get; set; }

    public DateTimeOffset? UpdateDate { get; set; }
}
