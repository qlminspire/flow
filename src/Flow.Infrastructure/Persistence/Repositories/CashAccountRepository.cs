using Flow.Domain.Accounts;
using Flow.Domain.Users;

namespace Flow.Infrastructure.Persistence.Repositories;

internal sealed class CashAccountRepository(FlowContext context)
    : BaseRepository<CashAccount, AccountId>(context), ICashAccountRepository
{
    public Task<CashAccount?> GetForUserAsync(UserId userId, AccountId cashAccountId,
        CancellationToken cancellationToken = default)
    {
        return All
            .Include(x => x.Currency)
            .Include(x => x.Category)
            .FirstOrDefaultAsync(x => x.UserId == userId && x.Id == cashAccountId, cancellationToken);
    }

    public Task<List<CashAccount>> GetAllForUserAsync(UserId userId, CancellationToken cancellationToken = default)
    {
        return All.AsNoTrackingWithIdentityResolution()
            .Include(x => x.Currency)
            .Include(x => x.Category)
            .Where(x => x.UserId == userId)
            .ToListAsync(cancellationToken);
    }
}