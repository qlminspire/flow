﻿namespace Flow.Application.Contracts.Persistence.Repositories;

public interface ISubscriptionRepository : IRepository<Subscription>
{
    Task<Subscription?> GetForUserAsync(Guid userId, Guid subscriptionId, CancellationToken cancellationToken = default);

    Task<List<Subscription>> GetAllForUserAsync(Guid userId, CancellationToken cancellationToken = default);
}
