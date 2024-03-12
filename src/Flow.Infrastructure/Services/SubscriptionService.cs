using Flow.Application.Models.Subscription;
using Flow.Domain.Subscriptions;

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
        ArgumentNullException.ThrowIfNull(unitOfWork);

        _unitOfWork = unitOfWork;
        _timeProvider = timeProvider;
        _currencyConversionRateService = currencyConversionRateService;

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

    public async Task<SubscriptionsMonthlyTotalDto> GetMonthlyTotalForUserAsync(Guid userId, string currency,
        CancellationToken cancellationToken = default)
    {
        var subscriptions = await _unitOfWork.Subscriptions.GetAllForUserAsync(userId, cancellationToken);

        var total = 0.0m;
        foreach (var subscription in subscriptions)
        {
            var rate = _currencyConversionRateService.GetConversionRate(subscription.Currency.Code, currency);
            var monthlyPrice = subscription.Price / subscription.PaymentFrequencyMonths;

            total += monthlyPrice * rate;
        }

        return new SubscriptionsMonthlyTotalDto(total, currency);
    }

    public async Task<SubscriptionDto> CreateAsync(Guid userId, CreateSubscriptionDto createSubscriptionDto,
        CancellationToken cancellationToken = default)
    {
        var currency = await _unitOfWork.Currencies.GetByIdAsync(createSubscriptionDto.CurrencyId, cancellationToken);
        if (currency is null)
            throw new ValidationException();

        var createDate = _timeProvider.GetUtcNow().UtcDateTime;
        var subscriptionResult = Subscription.Create(userId, createSubscriptionDto.Name, createSubscriptionDto.Price,
            createSubscriptionDto.PaymentFrequencyMonths, currency, createDate);
        var subscription = subscriptionResult.Value;

        _unitOfWork.Subscriptions.Create(subscription);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map(subscription);
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