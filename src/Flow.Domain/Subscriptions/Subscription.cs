using Ardalis.GuardClauses;
using Flow.Domain.Currencies;
using Flow.Domain.Users;

namespace Flow.Domain.Subscriptions;

public sealed class Subscription : AggregateRoot, IAuditable, IDeactivatable
{
    private Subscription(
        Guid id,
        Guid userId,
        SubscriptionName name,
        Money price,
        Guid currencyId,
        PaymentFrequencyMonths paymentFrequencyMonths,
        DateTime createdAt)
        : base(id)
    {
        UserId = Guard.Against.Default(userId);
        Name = Guard.Against.Null(name);
        Price = Guard.Against.Null(price);
        CurrencyId = Guard.Against.Default(currencyId);
        PaymentFrequencyMonths = Guard.Against.Null(paymentFrequencyMonths);
        CreatedAt = Guard.Against.Default(createdAt);
    }

    private Subscription()
    {
    }

    public SubscriptionName Name { get; private set; }

    public Money Price { get; private set; }

    public PaymentFrequencyMonths PaymentFrequencyMonths { get; private set; }

    public Guid CurrencyId { get; private set; }

    public Currency? Currency { get; private set; }

    public Guid UserId { get; private set; }

    public User? User { get; private set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsDeactivated { get; private set; }

    public DateTime? DeactivatedAt { get; private set; }

    public decimal GetMonthlyPrice()
    {
        return Price.Value / PaymentFrequencyMonths.Value;
    }

    public static Result<Subscription> Create(
        Guid userId,
        SubscriptionName name,
        Money price,
        PaymentFrequencyMonths paymentFrequencyMonths,
        Currency currency,
        DateTime createdAt)
    {
        var subscription =
            new Subscription(Guid.NewGuid(), userId, name, price, currency.Id, paymentFrequencyMonths, createdAt);

        return subscription;
    }
}