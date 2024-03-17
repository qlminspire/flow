using Flow.Domain.BankDeposits;
using Flow.Domain.Users;

namespace Flow.Infrastructure.Persistence.Repositories;

internal sealed class BankDepositRepository(FlowContext context)
    : BaseRepository<BankDeposit, BankDepositId>(context), IBankDepositRepository
{
    public Task<List<BankDeposit>> GetAllForUserAsync(UserId userId, CancellationToken cancellationToken = default)
    {
        return All.AsNoTrackingWithIdentityResolution()
            .Include(x => x.Currency)
            .Include(x => x.RefundAccount)
            .Include(x => x.Category)
            .Where(x => x.UserId == userId)
            .ToListAsync(cancellationToken);
    }

    public Task<BankDeposit?> GetForUserAsync(UserId userId, BankDepositId bankDepositId,
        CancellationToken cancellationToken = default)
    {
        return All
            .Include(x => x.Currency)
            .Include(x => x.RefundAccount)
            .Include(x => x.Category)
            .FirstOrDefaultAsync(x => x.UserId == userId && x.Id == bankDepositId, cancellationToken);
    }
}