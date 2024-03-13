using Flow.Domain.Currencies;
using Flow.Domain.Users;

namespace Flow.Domain.Debts;

public sealed class Debt : Entity, IAuditable
{
    private Debt(
        Guid id,
        User user,
        DebtName name,
        Money amount,
        Currency currency,
        DateTime createdAt
    ) : base(id)
    {
        UserId = user.Id;
        Name = name;
        Amount = amount;
        CurrencyId = currency.Id;
        CreatedAt = createdAt;
    }

    private Debt()
    {
    }

    public DebtName Name { get; private set; }

    public Money Amount { get; private set; }

    public Guid CurrencyId { get; private set; }

    public Currency? Currency { get; private set; }

    public Guid UserId { get; private set; }

    public User? User { get; private set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public static Result<Debt> Create(User user, DebtName name, Money amount, Currency currency, DateTime createdAt)
    {
        return new Debt(Guid.NewGuid(), user, name, amount, currency, createdAt);
    }
}