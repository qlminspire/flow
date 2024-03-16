using Flow.Domain.AccountOperations;
using Flow.Domain.Accounts;
using Flow.Domain.Users;

namespace Flow.Infrastructure.Persistence.Repositories;

internal sealed class AccountOperationRepository(FlowContext context)
    : BaseRepository<AccountOperation, AccountOperationId>(context), IAccountOperationRepository
{
    public Task<AccountOperation?> GetForUserAsync(UserId userId, AccountOperationId operationId,
        CancellationToken cancellationToken = default)
    {
        return All.Include(x => x.FromAccount)
            .Include(x => x.ToAccount)
            .FirstOrDefaultAsync(x =>
                ((x.FromAccount != null && x.FromAccount.UserId == userId) ||
                 (x.ToAccount != null && x.ToAccount.UserId == userId))
                && x.Id == operationId, cancellationToken);
    }

    public Task<List<AccountOperation>> GetAllIncomingOperationsAsync(AccountId accountId,
        CancellationToken cancellationToken = default)
    {
        return All.AsNoTrackingWithIdentityResolution()
            .Include(x => x.FromAccount)
            .Include(x => x.ToAccount)
            .Where(x => x.ToAccountId == accountId)
            .ToListAsync(cancellationToken);
    }

    public Task<List<AccountOperation>> GetAllOutgoingOperationsAsync(AccountId accountId,
        CancellationToken cancellationToken = default)
    {
        return All.AsNoTrackingWithIdentityResolution()
            .Include(x => x.FromAccount)
            .Include(x => x.ToAccount)
            .Where(x => x.FromAccountId == accountId)
            .ToListAsync(cancellationToken);
    }
}