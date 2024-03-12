using Ardalis.GuardClauses;

namespace Flow.Domain.Currencies;

public sealed class Currency : AggregateRoot, IAuditable, IDeactivatable
{
    private Currency(
        Guid id,
        string code,
        DateTime date)
        : base(id)
    {
        Code = Guard.Against.NullOrWhiteSpace(code);
        CreatedAt = Guard.Against.Default(date);
    }

    private Currency()
    {
    }

    public string Code { get; private set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsDeactivated { get; private set; }

    public DateTime? DeactivatedAt { get; private set; }

    public static Result<Currency> Create(string code, DateTime date)
    {
        var currency = new Currency(Guid.NewGuid(), code, date);
        return currency;
    }
}