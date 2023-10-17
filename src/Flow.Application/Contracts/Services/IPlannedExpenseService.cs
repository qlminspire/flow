using Flow.Application.Models.PlannedExpense;

namespace Flow.Application.Contracts.Services;

public interface IPlannedExpenseService
{
    Task<PlannedExpenseDto> GetAsync(Guid userId, Guid plannedExpenseId, CancellationToken cancellationToken = default);

    Task<List<PlannedExpenseDto>> GetAllAsync(Guid userId, CancellationToken cancellationToken = default);

    Task<MonthlyPlannedExpensesDto> GetAllForMonthAsync(Guid userId, CancellationToken cancellationToken = default);

    Task<PlannedExpenseDto> CreateAsync(Guid userId, CreatePlannedExpenseDto createPlannedExpenseDto, CancellationToken cancellationToken = default);

    Task UpdateAsync(Guid userId, Guid plannedExpenseId, UpdatePlannedExpenseDto updatePlannedExpenseDto, CancellationToken cancellationToken = default);

    Task DeleteAsync(Guid userId, Guid plannedExpenseId, CancellationToken cancellationToken = default);
}
