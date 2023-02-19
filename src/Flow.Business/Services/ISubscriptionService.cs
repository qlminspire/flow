using Flow.Business.Models.Subscription;

namespace Flow.Business.Services;

public interface ISubscriptionService
{
    Task<SubscriptionDto> GetAsync(Guid userId, Guid subscriptionId, CancellationToken cancellationToken = default);

    Task<List<SubscriptionDto>> GetAllAsync(Guid userId, CancellationToken cancellationToken = default);

    Task<SubscriptionDto> CreateAsync(Guid userId, CreateSubscriptionDto dto, CancellationToken cancellationToken = default);

    Task UpdateAsync(Guid userId, Guid subscriptionId, UpdateSubscriptionDto dto, CancellationToken cancellationToken = default);

    Task DeleteAsync(Guid userId, Guid subscriptionId, CancellationToken cancellationToken = default);
}
