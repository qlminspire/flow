using Flow.Domain.Users;

namespace Flow.Domain.PlannedExpenses;

public interface IPlannedExpenseRepository : IRepository<PlannedExpense, PlannedExpenseId>
{
    Task<PlannedExpense?> GetForUserAsync(UserId userId, PlannedExpenseId plannedExpenseId,
        CancellationToken cancellationToken = default);

    Task<List<PlannedExpense>> GetAllForUserAsync(UserId userId, CancellationToken cancellationToken = default);

    Task<List<PlannedExpense>> GetStartingFromDateAsync(UserId userId, DateTime fromDate,
        CancellationToken cancellationToken = default);
}