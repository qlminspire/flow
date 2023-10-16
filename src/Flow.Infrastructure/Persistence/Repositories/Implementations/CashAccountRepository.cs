using Flow.Application.Contracts.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Flow.Infrastructure.Persistence.Repositories.Implementations;

internal sealed class CashAccountRepository : BaseRepository<CashAccount>, ICashAccountRepository
{
    public CashAccountRepository(FlowContext context) : base(context)
    {
    }

    public Task<CashAccount?> GetForUserAsync(Guid userId, Guid cashAccountId, CancellationToken cancellationToken = default)
    {
        return All
            .Include(x => x.Currency)
            .FirstOrDefaultAsync(x => x.UserId == userId && x.Id == cashAccountId, cancellationToken);
    }

    public Task<List<CashAccount>> GetAllForUserAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return All.AsNoTracking()
            .Include(x => x.Currency)
            .Where(x => x.UserId == userId)
            .ToListAsync(cancellationToken);
    }
}
