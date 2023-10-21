using Microsoft.EntityFrameworkCore;

namespace Flow.Infrastructure.Persistence.Repositories;

internal sealed class AccountRepository : BaseRepository<Account>, IAccountRepository
{
    public AccountRepository(FlowContext context) : base(context)
    {
    }

    public Task<Account?> GetForUserAsync(Guid userId, Guid accountId, CancellationToken cancellationToken = default)
    {
        return All
            .Include(x => x.Currency)
            .Include(x => x.Category)
            .FirstOrDefaultAsync(x => x.UserId == userId && x.Id == accountId, cancellationToken);
    }
}
