using Flow.Domain.Debts;
using Flow.Domain.Users;

namespace Flow.Infrastructure.Persistence.Repositories;

internal sealed class DebtRepository(FlowContext context)
    : BaseRepository<Debt, DebtId>(context), IDebtRepository
{
    public Task<Debt?> GetForUserAsync(UserId userId, DebtId debtId, CancellationToken cancellationToken = default)
    {
        return All
            .Include(x => x.Currency)
            .FirstOrDefaultAsync(x => x.UserId == userId && x.Id == debtId, cancellationToken);
    }

    public Task<List<Debt>> GetAllForUserAsync(UserId userId, CancellationToken cancellationToken = default)
    {
        return All.AsNoTrackingWithIdentityResolution()
            .Include(x => x.Currency)
            .Where(x => x.UserId == userId)
            .ToListAsync(cancellationToken);
    }
}