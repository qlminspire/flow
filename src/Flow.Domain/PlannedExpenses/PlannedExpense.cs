using Flow.Domain.Currencies;
using Flow.Domain.Users;

namespace Flow.Domain.PlannedExpenses;

public sealed class PlannedExpense : Entity, IAuditable
{
    public string Name { get; set; }

    public decimal Amount { get; set; }

    public Guid UserId { get; set; }

    public User? User { get; set; }

    public Guid CurrencyId { get; set; }

    public Currency Currency { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}