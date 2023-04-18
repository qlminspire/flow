using Flow.Domain.Entities.Auth;

namespace Flow.Domain.Entities;

public sealed class Debt : BaseEntity<Guid>, IHasDate
{
    public string Name { get; set; }

    public decimal Amount { get; set; }

    public Guid CurrencyId { get; set; }

    public Currency Currency { get; set; }

    public Guid UserId { get; set; }

    public User User { get; set; }

    public DateTimeOffset? CreateDate { get; set; }

    public DateTimeOffset? UpdateDate { get; set; }
}
