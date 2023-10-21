using Microsoft.EntityFrameworkCore;

namespace Flow.Infrastructure.Persistence.Repositories;

internal sealed class AccountOperationRepository : BaseRepository<AccountOperation>, IAccountOperationRepository
{
    public AccountOperationRepository(FlowContext context) : base(context)
    {
    }

    public Task<AccountOperation?> GetForUserAsync(Guid userId, Guid operationId, CancellationToken cancellationToken = default)
    {
        return All.Include(x => x.FromAccount)
                  .Include(x => x.ToAccount)
                  .FirstOrDefaultAsync(x =>
                        ((x.FromAccount != null && x.FromAccount.UserId == userId) || (x.ToAccount != null && x.ToAccount.UserId == userId))
                        && x.Id == operationId, cancellationToken);
    }

    public Task<List<AccountOperation>> GetAllIncomingOperationsAsync(Guid accountId,
        CancellationToken cancellationToken = default)
    {
        return All.AsNoTrackingWithIdentityResolution()
            .Include(x => x.FromAccount)
            .Include(x => x.ToAccount)
            .Where(x => x.ToAccountId == accountId)
            .ToListAsync(cancellationToken);
    }

    public Task<List<AccountOperation>> GetAllOutgoingOperationsAsync(Guid accountId,
        CancellationToken cancellationToken = default)
    {
        return All.AsNoTrackingWithIdentityResolution()
            .Include(x => x.FromAccount)
            .Include(x => x.ToAccount)
            .Where(x => x.FromAccountId == accountId)
            .ToListAsync(cancellationToken);
    }
}