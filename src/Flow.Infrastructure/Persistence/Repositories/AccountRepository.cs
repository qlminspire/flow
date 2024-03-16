using Flow.Domain.Accounts;
using Flow.Domain.Users;

namespace Flow.Infrastructure.Persistence.Repositories;

internal sealed class AccountRepository(FlowContext context)
    : BaseRepository<Account, AccountId>(context), IAccountRepository
{
    public Task<Account?> GetForUserAsync(UserId userId, AccountId accountId,
        CancellationToken cancellationToken = default)
    {
        return All
            .Include(x => x.Currency)
            .Include(x => x.Category)
            .FirstOrDefaultAsync(x => x.UserId == userId && x.Id == accountId, cancellationToken);
    }
}