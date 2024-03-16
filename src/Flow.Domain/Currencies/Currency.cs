namespace Flow.Domain.Currencies;

public sealed class Currency : AggregateRoot<CurrencyId>, IAuditable, IDeactivatable
{
    private Currency(
        CurrencyId id,
        CurrencyCode code,
        DateTime createdAt)
        : base(id)
    {
        Code = code;
        CreatedAt = createdAt;
    }

    private Currency()
    {
    }

    public CurrencyCode Code { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime? UpdatedAt { get; private set; }

    public bool IsDeactivated { get; private set; }

    public DateTime? DeactivatedAt { get; private set; }

    public static Result<Currency> Create(CurrencyCode code, DateTime createdAt)
    {
        var currency = new Currency(new CurrencyId(Guid.NewGuid()), code, createdAt);
        return currency;
    }
}