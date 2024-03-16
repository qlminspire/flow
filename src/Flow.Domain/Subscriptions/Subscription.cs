using Flow.Domain.Currencies;
using Flow.Domain.Users;

namespace Flow.Domain.Subscriptions;

public sealed class Subscription : AggregateRoot<SubscriptionId>, IAuditable, IDeactivatable
{
    private Subscription(
        SubscriptionId id,
        UserId userId,
        SubscriptionName name,
        Money price,
        CurrencyId currencyId,
        PaymentFrequencyMonths paymentFrequencyMonths,
        DateTime createdAt)
        : base(id)
    {
        UserId = userId;
        Name = name;
        Price = price;
        CurrencyId = currencyId;
        PaymentFrequencyMonths = paymentFrequencyMonths;
        CreatedAt = createdAt;
    }

    private Subscription()
    {
    }

    public SubscriptionName Name { get; private set; }

    public Money Price { get; private set; }

    public PaymentFrequencyMonths PaymentFrequencyMonths { get; private set; }

    public CurrencyId CurrencyId { get; private set; }

    public Currency? Currency { get; private set; }

    public UserId UserId { get; private set; }

    public User? User { get; private set; }

    public decimal GetMonthlyPrice => Price.Value / PaymentFrequencyMonths.Value;

    public DateTime CreatedAt { get; private set; }

    public DateTime? UpdatedAt { get; private set; }

    public bool IsDeactivated { get; private set; }

    public DateTime? DeactivatedAt { get; private set; }

    public static Result<Subscription> Create(
        UserId userId,
        SubscriptionName name,
        Money price,
        PaymentFrequencyMonths paymentFrequencyMonths,
        Currency currency,
        DateTime createdAt)
    {
        var subscription =
            new Subscription(new SubscriptionId(Guid.NewGuid()), userId, name, price, currency.Id,
                paymentFrequencyMonths, createdAt);

        return subscription;
    }
}