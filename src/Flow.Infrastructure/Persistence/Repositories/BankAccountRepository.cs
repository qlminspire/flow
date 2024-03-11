using Flow.Domain.Accounts;

namespace Flow.Infrastructure.Persistence.Repositories;

internal sealed class BankAccountRepository(FlowContext context)
    : BaseRepository<BankAccount>(context), IBankAccountRepository
{
    public Task<BankAccount?> GetForUserAsync(Guid userId, Guid bankAccountId, CancellationToken cancellationToken)
    {
        return All
            .Include(x => x.Bank)
            .Include(x => x.Currency)
            .Include(x => x.Category)
            .FirstOrDefaultAsync(x => x.UserId == userId && x.Id == bankAccountId, cancellationToken);
    }

    public Task<List<BankAccount>> GetAllForUserAsync(Guid userId, CancellationToken cancellationToken)
    {
        return All.AsNoTrackingWithIdentityResolution()
            .Include(x => x.Bank)
            .Include(x => x.Currency)
            .Include(x => x.Category)
            .Where(x => x.UserId == userId)
            .ToListAsync(cancellationToken);
    }
}