using Ardalis.GuardClauses;

namespace Flow.Domain.Currencies;

public sealed class Currency : AggregateRoot, IAuditable, IDeactivatable
{
    private Currency(
        Guid id,
        CurrencyCode code,
        DateTime createdAt)
        : base(id)
    {
        Code = code;
        CreatedAt = Guard.Against.Default(createdAt);
    }

    private Currency()
    {
    }

    public CurrencyCode Code { get; private set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsDeactivated { get; private set; }

    public DateTime? DeactivatedAt { get; private set; }

    public static Result<Currency> Create(CurrencyCode code, DateTime createdAt)
    {
        var currency = new Currency(Guid.NewGuid(), code, createdAt);
        return currency;
    }
}