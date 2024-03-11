using Flow.Domain.Accounts;

namespace Flow.Infrastructure.Persistence.Repositories;

internal sealed class AccountRepository(FlowContext context)
    : BaseRepository<Account>(context), IAccountRepository
{
    public Task<Account?> GetForUserAsync(Guid userId, Guid accountId, CancellationToken cancellationToken = default)
    {
        return All
            .Include(x => x.Currency)
            .Include(x => x.Category)
            .FirstOrDefaultAsync(x => x.UserId == userId && x.Id == accountId, cancellationToken);
    }
}