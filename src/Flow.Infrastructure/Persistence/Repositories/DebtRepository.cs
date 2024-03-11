using Flow.Domain.Debts;

namespace Flow.Infrastructure.Persistence.Repositories;

internal sealed class DebtRepository(FlowContext context)
    : BaseRepository<Debt>(context), IDebtRepository
{
    public Task<Debt?> GetForUserAsync(Guid userId, Guid debtId, CancellationToken cancellationToken = default)
    {
        return All
            .Include(x => x.Currency)
            .FirstOrDefaultAsync(x => x.UserId == userId && x.Id == debtId, cancellationToken);
    }

    public Task<List<Debt>> GetAllForUserAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return All.AsNoTrackingWithIdentityResolution()
            .Include(x => x.Currency)
            .Where(x => x.UserId == userId)
            .ToListAsync(cancellationToken);
    }
}