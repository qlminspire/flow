﻿using Flow.Application.Models.Subscription;
using Flow.Domain.Currencies;
using Flow.Domain.Subscriptions;
using Flow.Domain.Users;

namespace Flow.Infrastructure.Services;

internal sealed class SubscriptionService : ISubscriptionService
{
    private readonly ICurrencyConversionRateService _currencyConversionRateService;
    private readonly SubscriptionMapper _mapper;
    private readonly TimeProvider _timeProvider;
    private readonly IUnitOfWork _unitOfWork;

    public SubscriptionService(IUnitOfWork unitOfWork, TimeProvider timeProvider,
        ICurrencyConversionRateService currencyConversionRateService)
    {
        _unitOfWork = unitOfWork;
        _timeProvider = timeProvider;
        _currencyConversionRateService = currencyConversionRateService;

        _mapper = new SubscriptionMapper();
    }

    public async Task<SubscriptionDto> GetForUserAsync(Guid userId, Guid subscriptionId,
        CancellationToken cancellationToken = default)
    {
        var subscription = await _unitOfWork.Subscriptions.GetForUserAsync(new UserId(userId),
                               new SubscriptionId(subscriptionId), cancellationToken)
                           ?? throw new NotFoundException(subscriptionId);
        return _mapper.Map(subscription);
    }

    public async Task<List<SubscriptionDto>> GetAllForUserAsync(Guid userId,
        CancellationToken cancellationToken = default)
    {
        var subscriptions = await _unitOfWork.Subscriptions.GetAllForUserAsync(new UserId(userId), cancellationToken);
        return _mapper.Map(subscriptions);
    }

    public async Task<SubscriptionsMonthlyTotalDto> GetMonthlyTotalForUserAsync(Guid userId, string currency,
        CancellationToken cancellationToken = default)
    {
        var targetCurrencyCode = CurrencyCode.Create(currency);
        // TODO: Check currency in database
        var subscriptions = await _unitOfWork.Subscriptions.GetAllForUserAsync(new UserId(userId), cancellationToken);

        var total = 0.0m;
        foreach (var subscription in subscriptions)
        {
            var monthlyPrice = subscription.GetMonthlyPrice;
            var sourceCurrencyCode = subscription.Currency!.Code;
            var rate = _currencyConversionRateService.GetConversionRate(sourceCurrencyCode,
                targetCurrencyCode.Value);

            total += monthlyPrice * rate;
        }

        return new SubscriptionsMonthlyTotalDto(total, currency);
    }

    public async Task<SubscriptionDto> CreateAsync(Guid userId, CreateSubscriptionDto createSubscriptionDto,
        CancellationToken cancellationToken = default)
    {
        var currencyCode = CurrencyCode.Create(createSubscriptionDto.Currency);

        var currency = await _unitOfWork.Currencies.GetByCurrencyCodeAsync(currencyCode.Value, cancellationToken);
        if (currency is null)
            throw new NotFoundException();

        var name = SubscriptionName.Create(createSubscriptionDto.Name);
        var price = Money.Create(createSubscriptionDto.Price);
        var paymentFrequency = PaymentFrequencyMonths.Create(createSubscriptionDto.PaymentFrequencyMonths);
        var createdAt = _timeProvider.GetUtcNow().UtcDateTime;

        var subscription = Subscription.Create(new UserId(userId), name.Value, price.Value,
            paymentFrequency.Value, currency, createdAt);

        _unitOfWork.Subscriptions.Create(subscription.Value);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map(subscription.Value);
    }

    public async Task DeleteAsync(Guid userId, Guid subscriptionId, CancellationToken cancellationToken = default)
    {
        var existingSubscription =
            await _unitOfWork.Subscriptions.GetForUserAsync(new UserId(userId), new SubscriptionId(subscriptionId),
                cancellationToken)
            ?? throw new NotFoundException(subscriptionId);

        _unitOfWork.Subscriptions.Delete(existingSubscription);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}