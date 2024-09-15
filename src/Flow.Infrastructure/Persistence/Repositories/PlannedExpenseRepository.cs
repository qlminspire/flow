using Flow.Application.Models.PlannedExpense;
using Flow.Domain.PlannedExpenses;
using Flow.Domain.Users;

namespace Flow.Infrastructure.Persistence.Repositories;

internal sealed class PlannedExpenseRepository(FlowContext context)
    : BaseRepository<PlannedExpense, PlannedExpenseId>(context), IPlannedExpenseRepository
{
    public Task<PlannedExpense?> GetForUserAsync(UserId userId, PlannedExpenseId plannedExpenseId,
        CancellationToken cancellationToken = default)
    {
        return All
            .Include(x => x.Currency)
            .FirstOrDefaultAsync(x => x.UserId == userId && x.Id == plannedExpenseId, cancellationToken);
    }

    public Task<List<PlannedExpense>> GetAllForUserAsync(UserId userId, CancellationToken cancellationToken = default)
    {
        return All.AsNoTrackingWithIdentityResolution()
            .Include(x => x.Currency)
            .Where(x => x.UserId == userId)
            .ToListAsync(cancellationToken);
    }

    public Task<List<PlannedExpense>> GetStartingFromDateAsync(UserId userId, DateTime fromDate,
        CancellationToken cancellationToken = default)
    {
        return All.AsNoTracking()
            .Include(x => x.Currency)
            .Where(x => x.UserId == userId &&
                        x.CreatedAt >= fromDate)
            .ToListAsync(cancellationToken);
    }

    public Task<List<MonthlyPlannedExpenseDto>> GetAggregatedByCurrencyAsync(UserId userId, DateOnly startDate,
        CancellationToken cancellationToken = default)
    {
        return All.AsNoTrackingWithIdentityResolution()
            .Include(x => x.Currency)
            .Where(x => x.UserId == userId)
            .GroupBy(x => x.Currency.Code)
            .Select(x => new MonthlyPlannedExpenseDto
            {
                Currency = x.Key.Value,
                Amount = x.Sum(z => z.Amount.Value)
            })
            .ToListAsync(cancellationToken);
    }
}