using Flow.DataAccess.Contracts.Repositories;
using Flow.Entities;

namespace Flow.DataAccess.Repositories.Implementations;

internal sealed class SubscriptionRepository : BaseRepository<Subscription>, ISubscriptionRepository
{
    public SubscriptionRepository(FlowContext context) : base(context)
    {
    }

    public IQueryable<Subscription> GetAllByUser(Guid userId)
    {
        return GetByCondition(x => x.UserId == userId, true);
    }

    public IQueryable<Subscription> GetByUser(Guid userId, Guid subscriptionId)
    {
        return GetByCondition(x => x.UserId == userId && x.Id == subscriptionId, true);
    }
}
