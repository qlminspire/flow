using Flow.Application.Models.Subscription;
using OneOf;
using OneOf.Types;

namespace Flow.Application.Contracts.Services;

public interface ISubscriptionService
{
    Task<OneOf<SubscriptionDto, NotFound>> GetAsync(Guid userId, Guid subscriptionId, CancellationToken cancellationToken = default);

    Task<List<SubscriptionDto>> GetAllAsync(Guid userId, CancellationToken cancellationToken = default);

    Task<SubscriptionDto> CreateAsync(Guid userId, CreateSubscriptionDto dto, CancellationToken cancellationToken = default);

    Task<OneOf<Success, NotFound>> UpdateAsync(Guid userId, Guid subscriptionId, UpdateSubscriptionDto dto, CancellationToken cancellationToken = default);

    Task<OneOf<Success, NotFound>> DeleteAsync(Guid userId, Guid subscriptionId, CancellationToken cancellationToken = default);
}
