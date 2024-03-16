using Flow.Domain.Users;

namespace Flow.Domain.Subscriptions;

public interface ISubscriptionRepository : IRepository<Subscription, SubscriptionId>
{
    Task<Subscription?> GetForUserAsync(UserId userId, SubscriptionId subscriptionId,
        CancellationToken cancellationToken = default);

    Task<List<Subscription>> GetAllForUserAsync(UserId userId, CancellationToken cancellationToken = default);
}