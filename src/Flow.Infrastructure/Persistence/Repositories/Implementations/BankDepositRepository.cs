using Flow.Application.Contracts.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Flow.Infrastructure.Persistence.Repositories.Implementations;

internal sealed class BankDepositRepository : BaseRepository<BankDeposit>, IBankDepositRepository
{
    public BankDepositRepository(FlowContext context) : base(context)
    {
    }

    public Task<BankDeposit?> GetForUserAsync(Guid userId, Guid bankDepositId, CancellationToken cancellationToken)
    {
        return All
            .Include(x => x.Currency)
            .Include(x => x.RefundAccount)
            .Include(x => x.Category)
            .FirstOrDefaultAsync(x => x.UserId == userId && x.Id == bankDepositId, cancellationToken);
    }

    public Task<List<BankDeposit>> GetAllForUserAsync(Guid userId, CancellationToken cancellationToken)
    {
        return All.AsNoTrackingWithIdentityResolution()
            .Include(x => x.Currency)
            .Include(x => x.RefundAccount)
            .Include(x => x.Category)
            .Where(x => x.UserId == userId)
            .ToListAsync(cancellationToken);
    }
}
