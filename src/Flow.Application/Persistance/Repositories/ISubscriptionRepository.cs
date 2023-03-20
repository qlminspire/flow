using Flow.Domain.Entities;

namespace Flow.Application.Persistance.Repositories;

public interface ISubscriptionRepository : IRepository<Subscription>
{
    IQueryable<Subscription> GetAllByUser(Guid userId);

    IQueryable<Subscription> GetByUser(Guid userId, Guid subscriptionId);
}
