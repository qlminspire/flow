namespace Flow.Domain.Entities;

public abstract class Account : BaseEntity, IHasDate
{
    public decimal Amount { get; set; }

    public Guid CurrencyId { get; set; }

    public Currency? Currency { get; set; }

    public Guid UserId { get; set; }

    public User User { get; set; } = null!;

    public Guid? CategoryId { get; set; }

    public UserCategory? Category { get; set; }

    public ICollection<AccountOperation> Operations { get; set; } = Array.Empty<AccountOperation>();

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }
}
