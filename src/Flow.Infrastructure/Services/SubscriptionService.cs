using AutoMapper;
using AutoMapper.QueryableExtensions;
using Flow.Application.Contracts.Persistence;
using Flow.Application.Contracts.Services;
using Flow.Application.Exceptions;
using Flow.Application.Models.Subscription;
using Flow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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
        var subscription = await _unitOfWork.Subscriptions.GetByUser(userId, subscriptionId)
            .Include(x => x.Currency)
            .ProjectTo<SubscriptionDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return subscription is not null ? subscription : throw new NotFoundException();
    }

    public Task<List<SubscriptionDto>> GetAllAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.Subscriptions.GetAllByUser(userId)
            .Include(x => x.Currency)
            .ProjectTo<SubscriptionDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }

    public async Task<SubscriptionDto> CreateAsync(Guid userId, CreateSubscriptionDto createSubscriptionDto, CancellationToken cancellationToken = default)
    {
        var subscription = _mapper.Map<Subscription>(createSubscriptionDto);
        subscription.UserId = userId;

        _unitOfWork.Subscriptions.Create(subscription);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var currency = await _unitOfWork.Currencies.GetByCondition(x => x.Id == subscription.CurrencyId)
            .FirstOrDefaultAsync(CancellationToken.None);
        subscription.Currency = currency!;

        return _mapper.Map<SubscriptionDto>(subscription);
    }

    public async Task UpdateAsync(Guid userId, Guid subscriptionId, UpdateSubscriptionDto dto, CancellationToken cancellationToken = default)
    {
        var existingSubscription = await _unitOfWork.Subscriptions.GetByUser(userId, userId)
            .FirstOrDefaultAsync(cancellationToken);
        if (existingSubscription == null)
            throw new NotFoundException();

        _mapper.Map(dto, existingSubscription);

        _unitOfWork.Subscriptions.Update(existingSubscription);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid userId, Guid subscriptionId, CancellationToken cancellationToken = default)
    {
        var subscription = await _unitOfWork.Subscriptions.GetByUser(userId, subscriptionId)
            .FirstOrDefaultAsync(cancellationToken);
        if (subscription == null)
            throw new NotFoundException();

        _unitOfWork.Subscriptions.Delete(subscription);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
