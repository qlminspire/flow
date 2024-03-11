using Flow.Domain.Currencies;
using Flow.Domain.Users;

namespace Flow.Domain.Subscriptions;

public sealed class Subscription : Entity, IAuditable
{
    public string Service { get; set; } = null!;

    public decimal Price { get; set; }

    public Guid CurrencyId { get; set; }

    public Currency? Currency { get; set; }

    public Guid UserId { get; set; }

    public User? User { get; set; }

    public bool? IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}