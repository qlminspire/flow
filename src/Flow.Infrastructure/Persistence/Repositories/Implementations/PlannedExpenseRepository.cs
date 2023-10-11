using Flow.Application.Contracts.Persistence.Repositories;
using Flow.Application.Models.PlannedExpense;
using Microsoft.EntityFrameworkCore;

namespace Flow.Infrastructure.Persistence.Repositories.Implementations;

internal sealed class PlannedExpenseRepository : BaseRepository<PlannedExpense>, IPlannedExpenseRepository
{
    public PlannedExpenseRepository(FlowContext context) : base(context)
    {
    }

    public Task<List<MonthlyPlannedExpenseDto>> GetAggregatedByCurrencyAsync(Guid userId, DateOnly startDate, CancellationToken cancellationToken)
    {
        return All.AsNoTracking().AsQueryable().Where(x => x.UserId == userId && x.ExpenseDate >= startDate)
            .Include(x => x.Currency)
            .GroupBy(x => x.Currency.Code)
            .Select(x => new MonthlyPlannedExpenseDto
            {
                Currency = x.Key,
                Amount = x.Sum(z => z.Amount)
            })
            .ToListAsync(cancellationToken);
    }
}
