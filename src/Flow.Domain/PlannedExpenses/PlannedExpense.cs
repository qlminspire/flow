using Flow.Domain.Currencies;
using Flow.Domain.Users;

namespace Flow.Domain.PlannedExpenses;

public sealed class PlannedExpense : AggregateRoot<PlannedExpenseId>, IAuditable
{
    private PlannedExpense(
        PlannedExpenseId id,
        PlannedExpenseName name,
        Money amount,
        UserId userId,
        CurrencyId currencyId,
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

    public UserId UserId { get; private set; }

    public User? User { get; private set; }

    public CurrencyId CurrencyId { get; private set; }

    public Currency Currency { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime? UpdatedAt { get; private set; }

    public static Result<PlannedExpense> Create(UserId userId, PlannedExpenseName plannedExpenseName, Money amount,
        CurrencyId currencyId, DateTime createdAt)
    {
        return new PlannedExpense(new PlannedExpenseId(Guid.NewGuid()), plannedExpenseName, amount, userId, currencyId,
            createdAt);
    }
}