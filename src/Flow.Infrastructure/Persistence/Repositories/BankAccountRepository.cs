using Flow.Domain.Accounts;
using Flow.Domain.Users;

namespace Flow.Infrastructure.Persistence.Repositories;

internal sealed class BankAccountRepository(FlowContext context)
    : BaseRepository<BankAccount, AccountId>(context), IBankAccountRepository
{
    public Task<BankAccount?> GetForUserAsync(UserId userId, AccountId bankAccountId,
        CancellationToken cancellationToken = default)
    {
        return All
            .Include(x => x.Bank)
            .Include(x => x.Currency)
            .Include(x => x.Category)
            .FirstOrDefaultAsync(x => x.UserId == userId && x.Id == bankAccountId, cancellationToken);
    }

    public Task<List<BankAccount>> GetAllForUserAsync(UserId userId, CancellationToken cancellationToken = default)
    {
        return All.AsNoTrackingWithIdentityResolution()
            .Include(x => x.Bank)
            .Include(x => x.Currency)
            .Include(x => x.Category)
            .Where(x => x.UserId == userId)
            .ToListAsync(cancellationToken);
    }
}