using Flow.Application.Models.Subscription;

namespace Flow.Infrastructure.Services;

internal sealed class SubscriptionService : ISubscriptionService
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly SubscriptionMapper _mapper;

    public SubscriptionService(IUnitOfWork unitOfWork)
    {
        ArgumentNullException.ThrowIfNull(unitOfWork, nameof(unitOfWork));

        _unitOfWork = unitOfWork;

        _mapper = new();
    }

    public async Task<SubscriptionDto> GetAsync(Guid userId, Guid subscriptionId, CancellationToken cancellationToken = default)
    {
        var subscription = await _unitOfWork.Subscriptions.GetByIdAsync(subscriptionId, cancellationToken)
            ?? throw new NotFoundException();
        return _mapper.Map(subscription);
    }

    public async Task<List<SubscriptionDto>> GetAllAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var subscriptions = await _unitOfWork.Subscriptions.GetAsync(x => x.UserId == userId, cancellationToken);
        return _mapper.Map(subscriptions);
    }

    public async Task<SubscriptionDto> CreateAsync(Guid userId, CreateSubscriptionDto createSubscriptionDto, CancellationToken cancellationToken = default)
    {
        var subscription = _mapper.Map(createSubscriptionDto);
        subscription.UserId = userId;

        _unitOfWork.Subscriptions.Create(subscription);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var currency = await _unitOfWork.Currencies.GetByIdAsync(subscription.CurrencyId, cancellationToken);
        subscription.Currency = currency!;

        return _mapper.Map(subscription);
    }

    public async Task UpdateAsync(Guid userId, Guid subscriptionId, UpdateSubscriptionDto dto, CancellationToken cancellationToken = default)
    {
        var existingSubscription = await _unitOfWork.Subscriptions.GetByIdAsync(subscriptionId, cancellationToken)
            ?? throw new NotFoundException();

        _mapper.Map(existingSubscription, dto);

        _unitOfWork.Subscriptions.Update(existingSubscription);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid userId, Guid subscriptionId, CancellationToken cancellationToken = default)
    {
        var existingSubscription = await _unitOfWork.Subscriptions.GetByIdAsync(subscriptionId, cancellationToken)
            ?? throw new NotFoundException();

        _unitOfWork.Subscriptions.Delete(existingSubscription);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
