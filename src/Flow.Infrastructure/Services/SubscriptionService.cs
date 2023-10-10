using AutoMapper;
using Flow.Application.Contracts.Persistence;
using Flow.Application.Contracts.Services;
using Flow.Application.Exceptions;
using Flow.Application.Models.Subscription;
using Flow.Domain.Entities;

namespace Flow.Infrastructure.Services;

internal sealed class SubscriptionService : ISubscriptionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SubscriptionService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<SubscriptionDto> GetAsync(Guid userId, Guid subscriptionId, CancellationToken cancellationToken = default)
    {
        var subscription = await _unitOfWork.Subscriptions.GetByIdAsync(subscriptionId, cancellationToken)
            ?? throw new NotFoundException();
        return _mapper.Map<SubscriptionDto>(subscription);
    }

    public async Task<List<SubscriptionDto>> GetAllAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var subscription = await _unitOfWork.Subscriptions.GetAsync(x => x.UserId == userId, cancellationToken);
        return _mapper.Map<List<SubscriptionDto>>(subscription);
    }

    public async Task<SubscriptionDto> CreateAsync(Guid userId, CreateSubscriptionDto createSubscriptionDto, CancellationToken cancellationToken = default)
    {
        var subscription = _mapper.Map<Subscription>(createSubscriptionDto);
        subscription.UserId = userId;

        _unitOfWork.Subscriptions.Create(subscription);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var currency = await _unitOfWork.Currencies.GetByIdAsync(subscription.CurrencyId, cancellationToken);
        subscription.Currency = currency!;

        return _mapper.Map<SubscriptionDto>(subscription);
    }

    public async Task UpdateAsync(Guid userId, Guid subscriptionId, UpdateSubscriptionDto dto, CancellationToken cancellationToken = default)
    {
        var existingSubscription = await _unitOfWork.Subscriptions.GetByIdAsync(subscriptionId, cancellationToken)
            ?? throw new NotFoundException();

        _mapper.Map(dto, existingSubscription);

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
