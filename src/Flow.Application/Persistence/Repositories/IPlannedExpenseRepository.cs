using Flow.Application.Models.PlannedExpense;

namespace Flow.Application.Persistence.Repositories;

public interface IPlannedExpenseRepository : IRepository<PlannedExpense>
{
    Task<PlannedExpense?> GetForUserAsync(Guid userId, Guid plannedExpenseId, CancellationToken cancellationToken = default);

    Task<List<PlannedExpense>> GetAllForUserAsync(Guid userId, CancellationToken cancellationToken = default);

    Task<List<MonthlyPlannedExpenseDto>> GetAggregatedByCurrencyAsync(Guid userId, DateOnly startDate, CancellationToken cancellationToken = default);
}
