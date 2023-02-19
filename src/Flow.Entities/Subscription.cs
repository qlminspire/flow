using Flow.Entities.Core;
using Flow.Entities.Core.Interfaces;

namespace Flow.Entities;

public sealed class Subscription : BaseEntity<Guid>, IHasDate
{
    public string Service { get; set; } = null!;

    public decimal Price { get; set; }

    public Guid CurrencyId { get; set; }

    public Currency Currency { get; set; }

    public Guid UserId { get; set; }

    public User User { get; set; }

    public DateTimeOffset? PaymentDate { get; set; }

    public int? PaymentPeriod { get; set; }

    public bool? IsActive { get; set; }

    public DateTimeOffset? CreateDate { get; set; }

    public DateTimeOffset? UpdateDate { get; set; }
}
