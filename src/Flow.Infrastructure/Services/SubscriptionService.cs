using Flow.Application.Models.Subscription;

namespace Flow.Infrastructure.Services;

internal sealed class SubscriptionService : ISubscriptionService
{
    private readonly SubscriptionMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public SubscriptionService(IUnitOfWork unitOfWork)
    {
        ArgumentNullException.ThrowIfNull(unitOfWork);

        _unitOfWork = unitOfWork;

        _mapper = new SubscriptionMapper();
    }

    public async Task<SubscriptionDto> GetForUserAsync(Guid userId, Guid subscriptionId,
        CancellationToken cancellationToken = default)
    {
        var subscription = await _unitOfWork.Subscriptions.GetForUserAsync(userId, subscriptionId, cancellationToken)
                           ?? throw new NotFoundException();
        return _mapper.Map(subscription);
    }

    public async Task<List<SubscriptionDto>> GetAllForUserAsync(Guid userId,
        CancellationToken cancellationToken = default)
    {
        var subscriptions = await _unitOfWork.Subscriptions.GetAllForUserAsync(userId, cancellationToken);
        return _mapper.Map(subscriptions);
    }

    public async Task<SubscriptionDto> CreateAsync(Guid userId, CreateSubscriptionDto createSubscriptionDto,
        CancellationToken cancellationToken = default)
    {
        var currency = await _unitOfWork.Currencies.GetByIdAsync(createSubscriptionDto.CurrencyId, cancellationToken);
        if (currency is null)
            throw new ValidationException();

        var subscription = _mapper.Map(createSubscriptionDto);
        subscription.UserId = userId;

        _unitOfWork.Subscriptions.Create(subscription);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map(subscription);
    }

    public async Task UpdateAsync(Guid userId, Guid subscriptionId, UpdateSubscriptionDto updateSubscriptionDto,
        CancellationToken cancellationToken = default)
    {
        var existingSubscription =
            await _unitOfWork.Subscriptions.GetForUserAsync(userId, subscriptionId, cancellationToken)
            ?? throw new NotFoundException();

        _mapper.Map(updateSubscriptionDto, existingSubscription);

        _unitOfWork.Subscriptions.Update(existingSubscription);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid userId, Guid subscriptionId, CancellationToken cancellationToken = default)
    {
        var existingSubscription =
            await _unitOfWork.Subscriptions.GetForUserAsync(userId, subscriptionId, cancellationToken)
            ?? throw new NotFoundException();

        _unitOfWork.Subscriptions.Delete(existingSubscription);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}