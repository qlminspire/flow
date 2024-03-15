using Flow.Domain.BankDeposits;

namespace Flow.Infrastructure.Persistence.Repositories;

internal sealed class BankDepositRepository(FlowContext context)
    : BaseRepository<BankDeposit>(context), IBankDepositRepository
{
    public Task<BankDeposit?> GetForUserAsync(Guid userId, Guid bankDepositId,
        CancellationToken cancellationToken = default)
    {
        return All
            .Include(x => x.Currency)
            .Include(x => x.RefundAccount)
            .Include(x => x.Category)
            .FirstOrDefaultAsync(x => x.UserId == userId && x.Id == bankDepositId, cancellationToken);
    }

    public Task<List<BankDeposit>> GetAllForUserAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return All.AsNoTrackingWithIdentityResolution()
            .Include(x => x.Currency)
            .Include(x => x.RefundAccount)
            .Include(x => x.Category)
            .Where(x => x.UserId == userId)
            .ToListAsync(cancellationToken);
    }
}