using Flow.Domain.Currencies;
using Flow.Domain.Users;

namespace Flow.Domain.Debts;

public sealed class Debt : Entity, IAuditable
{
    public string Name { get; set; }

    public decimal Amount { get; set; }

    public Guid CurrencyId { get; set; }

    public Currency? Currency { get; set; }

    public Guid UserId { get; set; }

    public User? User { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }
}