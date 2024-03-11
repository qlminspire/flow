using Flow.Domain.Subscriptions;

namespace Flow.Infrastructure.Persistence.Repositories;

internal sealed class SubscriptionRepository(FlowContext context)
    : BaseRepository<Subscription>(context), ISubscriptionRepository
{
    public Task<Subscription?> GetForUserAsync(Guid userId, Guid subscriptionId,
        CancellationToken cancellationToken = default)
    {
        return All
            .Include(x => x.Currency)
            .FirstOrDefaultAsync(x => x.UserId == userId && x.Id == subscriptionId, cancellationToken);
    }

    public Task<List<Subscription>> GetAllForUserAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return All.AsNoTrackingWithIdentityResolution()
            .Include(x => x.Currency)
            .Where(x => x.UserId == userId)
            .ToListAsync(cancellationToken);
    }
}