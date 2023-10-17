using Flow.Application.Contracts.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Flow.Infrastructure.Persistence.Repositories.Implementations;

internal sealed class DebtRepository : BaseRepository<Debt>, IDebtRepository
{
    public DebtRepository(FlowContext context) : base(context)
    {
    }

    public Task<Debt?> GetForUserAsync(Guid userId, Guid debtId, CancellationToken cancellationToken = default)
    {
        return All
            .Include(x => x.Currency)
            .FirstOrDefaultAsync(x => x.UserId == userId && x.Id == debtId, cancellationToken);
    }

    public Task<List<Debt>> GetAllForUserAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return All.AsNoTrackingWithIdentityResolution()
            .Include(x => x.Currency)
            .Where(x => x.UserId == userId)
            .ToListAsync(cancellationToken);
    }
}
