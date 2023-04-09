using Flow.Domain.Entities.Auth;

namespace Flow.Domain.Entities;

public abstract class Account : BaseEntity<Guid>, IHasDate
{
    public decimal Amount { get; set; }

    public Guid CurrencyId { get; set; }

    public Currency? Currency { get; set; }

    public Guid UserId { get; set; }

    public User User { get; set; } = null!;

    public Guid? CategoryId { get; set; }

    public UserCategory? Category { get; set; }

    public ICollection<AccountOperation> Operations { get; set; } = new List<AccountOperation>();

    public DateTimeOffset? CreateDate { get; set; }

    public DateTimeOffset? UpdateDate { get; set; }
}
