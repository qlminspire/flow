using Ardalis.GuardClauses;
using Flow.Domain.Currencies;
using Flow.Domain.Users;

namespace Flow.Domain.Subscriptions;

public sealed class Subscription : AggregateRoot, IAuditable, IDeactivatable
{
    private Subscription(
        Guid id,
        Guid userId,
        string name,
        decimal price,
        Guid currencyId,
        int paymentFrequencyMonths,
        DateTime createdAt)
        : base(id)
    {
        UserId = Guard.Against.Default(userId);
        Name = Guard.Against.NullOrWhiteSpace(name);
        Price = Guard.Against.NegativeOrZero(price);
        CurrencyId = Guard.Against.Default(currencyId);
        PaymentFrequencyMonths = Guard.Against.NegativeOrZero(paymentFrequencyMonths);
        CreatedAt = Guard.Against.Default(createdAt);
    }

    private Subscription()
    {
    }

    public string Name { get; private set; }

    public decimal Price { get; private set; }

    public int PaymentFrequencyMonths { get; private set; }

    public Guid CurrencyId { get; private set; }

    public Currency? Currency { get; private set; }

    public Guid UserId { get; private set; }

    public User? User { get; private set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsDeactivated { get; private set; }

    public DateTime? DeactivatedAt { get; private set; }

    public static Result<Subscription> Create(
        Guid userId,
        string name,
        decimal price,
        int paymentFrequencyMonths,
        Currency currency,
        DateTime date)
    {
        var subscription =
            new Subscription(Guid.NewGuid(), userId, name, price, currency.Id, paymentFrequencyMonths, date);

        return subscription;
    }
}