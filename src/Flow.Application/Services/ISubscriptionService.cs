using Flow.Application.Models.Subscription;

namespace Flow.Application.Services;

public interface ISubscriptionService
{
    Task<SubscriptionDto> GetForUserAsync(Guid userId, Guid subscriptionId,
        CancellationToken cancellationToken = default);

    Task<List<SubscriptionDto>> GetAllForUserAsync(Guid userId, CancellationToken cancellationToken = default);

    Task<SubscriptionDto> CreateAsync(Guid userId, CreateSubscriptionDto createSubscriptionDto,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(Guid userId, Guid subscriptionId, CancellationToken cancellationToken = default);
}