using Flow.Entities;

namespace Flow.DataAccess.Contracts.Repositories;

public interface ISubscriptionRepository : IRepository<Subscription>
{
    IQueryable<Subscription> GetAllByUser(Guid userId);

    IQueryable<Subscription> GetByUser(Guid userId, Guid subscriptionId);
}
