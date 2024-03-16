using Flow.Domain.Subscriptions;
using Flow.Domain.Users;

namespace Flow.Infrastructure.Persistence.Repositories;

internal sealed class SubscriptionRepository(FlowContext context)
    : BaseRepository<Subscription, SubscriptionId>(context), ISubscriptionRepository
{
    public Task<Subscription?> GetForUserAsync(UserId userId, SubscriptionId subscriptionId,
        CancellationToken cancellationToken = default)
    {
        return All
            .Include(x => x.Currency)
            .FirstOrDefaultAsync(x => x.UserId == userId && x.Id == subscriptionId, cancellationToken);
    }

    public Task<List<Subscription>> GetAllForUserAsync(UserId userId, CancellationToken cancellationToken = default)
    {
        return All.AsNoTrackingWithIdentityResolution()
            .Include(x => x.Currency)
            .Where(x => x.UserId == userId)
            .ToListAsync(cancellationToken);
    }
}