using Flow.Domain.Accounts;

namespace Flow.Infrastructure.Persistence.Repositories;

internal sealed class CashAccountRepository(FlowContext context)
    : BaseRepository<CashAccount>(context), ICashAccountRepository
{
    public Task<CashAccount?> GetForUserAsync(Guid userId, Guid cashAccountId,
        CancellationToken cancellationToken = default)
    {
        return All
            .Include(x => x.Currency)
            .Include(x => x.Category)
            .FirstOrDefaultAsync(x => x.UserId == userId && x.Id == cashAccountId, cancellationToken);
    }

    public Task<List<CashAccount>> GetAllForUserAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return All.AsNoTrackingWithIdentityResolution()
            .Include(x => x.Currency)
            .Include(x => x.Category)
            .Where(x => x.UserId == userId)
            .ToListAsync(cancellationToken);
    }
}