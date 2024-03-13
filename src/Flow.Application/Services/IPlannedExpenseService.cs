using Flow.Application.Models.PlannedExpense;

namespace Flow.Application.Services;

public interface IPlannedExpenseService
{
    Task<PlannedExpenseDto> GetAsync(Guid userId, Guid plannedExpenseId, CancellationToken cancellationToken = default);

    Task<List<PlannedExpenseDto>> GetAllAsync(Guid userId, CancellationToken cancellationToken = default);

    Task<MonthlyPlannedExpensesDto> GetMonthlyTotalAsync(Guid userId, string currency,
        CancellationToken cancellationToken = default);

    Task<PlannedExpenseDto> CreateAsync(Guid userId, CreatePlannedExpenseDto createPlannedExpenseDto,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(Guid userId, Guid plannedExpenseId, CancellationToken cancellationToken = default);
}