namespace Flow.Domain.PlannedExpenses;

public interface IPlannedExpenseRepository : IRepository<PlannedExpense>
{
    Task<PlannedExpense?> GetForUserAsync(Guid userId, Guid plannedExpenseId,
        CancellationToken cancellationToken = default);

    Task<List<PlannedExpense>> GetAllForUserAsync(Guid userId, CancellationToken cancellationToken = default);

    Task<List<PlannedExpense>> GetStartingFromDateAsync(Guid userId, DateTime fromDate,
        CancellationToken cancellationToken = default);
}