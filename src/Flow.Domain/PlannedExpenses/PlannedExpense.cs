using Flow.Domain.Currencies;
using Flow.Domain.Shared;
using Flow.Domain.Users;

namespace Flow.Domain.PlannedExpenses;

public sealed class PlannedExpense : AggregateRoot, IAuditable
{
    private PlannedExpense(
        Guid id,
        PlannedExpenseName name,
        Money amount,
        Guid userId,
        Guid currencyId,
        DateTime createdAt
    ) : base(id)
    {
        Name = name;
        Amount = amount;
        UserId = userId;
        CurrencyId = currencyId;
        CreatedAt = createdAt;
    }

    private PlannedExpense()
    {
    }

    public PlannedExpenseName Name { get; private set; }

    public Money Amount { get; private set; }

    public Guid UserId { get; private set; }

    public User? User { get; private set; }

    public Guid CurrencyId { get; private set; }

    public Currency Currency { get; private set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public static Result<PlannedExpense> Create(Guid userId, PlannedExpenseName plannedExpenseName, Money amount,
        Guid currencyId, DateTime createdAt)
    {
        return new PlannedExpense(Guid.NewGuid(), plannedExpenseName, amount, userId, currencyId, createdAt);
    }
}