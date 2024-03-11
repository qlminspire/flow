using Flow.Application.Models.PlannedExpense;
using Flow.Domain.PlannedExpenses;

namespace Flow.Infrastructure.Persistence.Repositories;

internal sealed class PlannedExpenseRepository(FlowContext context)
    : BaseRepository<PlannedExpense>(context), IPlannedExpenseRepository
{
    public Task<PlannedExpense?> GetForUserAsync(Guid userId, Guid plannedExpenseId,
        CancellationToken cancellationToken = default)
    {
        return All
            .Include(x => x.Currency)
            .FirstOrDefaultAsync(x => x.UserId == userId && x.Id == plannedExpenseId, cancellationToken);
    }

    public Task<List<PlannedExpense>> GetAllForUserAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return All.AsNoTrackingWithIdentityResolution()
            .Include(x => x.Currency)
            .Where(x => x.UserId == userId)
            .ToListAsync(cancellationToken);
    }

    public Task<List<MonthlyPlannedExpenseDto>> GetAggregatedByCurrencyAsync(Guid userId, DateOnly startDate,
        CancellationToken cancellationToken = default)
    {
        return All.AsNoTrackingWithIdentityResolution()
            .Include(x => x.Currency)
            .Where(x => x.UserId == userId)
            .GroupBy(x => x.Currency.Code)
            .Select(x => new MonthlyPlannedExpenseDto
            {
                Currency = x.Key,
                Amount = x.Sum(z => z.Amount)
            })
            .ToListAsync(cancellationToken);
    }
}