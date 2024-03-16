using Flow.Application.Models.PlannedExpense;
using Flow.Domain.Currencies;
using Flow.Domain.PlannedExpenses;
using Flow.Domain.Users;

namespace Flow.Infrastructure.Services;

internal sealed class PlannedExpenseService : IPlannedExpenseService
{
    private readonly ICurrencyConversionRateService _currencyConversionRateService;

    private readonly PlannedExpenseMapper _mapper;
    private readonly TimeProvider _timeProvider;
    private readonly IUnitOfWork _unitOfWork;

    public PlannedExpenseService(IUnitOfWork unitOfWork, ICurrencyConversionRateService currencyConversionRateService,
        TimeProvider timeProvider)
    {
        ArgumentNullException.ThrowIfNull(unitOfWork);

        _unitOfWork = unitOfWork;
        _currencyConversionRateService = currencyConversionRateService;
        _timeProvider = timeProvider;

        _mapper = new PlannedExpenseMapper();
    }

    public async Task<PlannedExpenseDto> GetAsync(Guid userId, Guid plannedExpenseId,
        CancellationToken cancellationToken = default)
    {
        var plannedExpense =
            await _unitOfWork.PlannedExpenses.GetForUserAsync(new UserId(userId),
                new PlannedExpenseId(plannedExpenseId), cancellationToken)
            ?? throw new NotFoundException(nameof(plannedExpenseId), plannedExpenseId.ToString());

        return _mapper.Map(plannedExpense);
    }

    public async Task<List<PlannedExpenseDto>> GetAllAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var plannedExpenses =
            await _unitOfWork.PlannedExpenses.GetAllForUserAsync(new UserId(userId), cancellationToken);
        return _mapper.Map(plannedExpenses);
    }

    public async Task<MonthlyPlannedExpensesDto> GetMonthlyTotalAsync(Guid userId,
        string currency,
        CancellationToken cancellationToken = default)
    {
        var currentDate = _timeProvider.GetUtcNow().UtcDateTime;
        var startOfTheMonthDate = new DateOnly(currentDate.Year, currentDate.Month, 1);
        var startOfTheMonthDateTime = startOfTheMonthDate.ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc);

        var targetCurrencyCode = CurrencyCode.Create(currency);

        var monthlyPlannedExpenses =
            await _unitOfWork.PlannedExpenses.GetStartingFromDateAsync(new UserId(userId), startOfTheMonthDateTime,
                cancellationToken);

        decimal totalAmount = 0;
        foreach (var expense in monthlyPlannedExpenses)
        {
            var sourceCurrencyCode = expense.Currency.Code;
            var rate = _currencyConversionRateService.GetConversionRate(sourceCurrencyCode, targetCurrencyCode.Value);

            totalAmount += expense.Amount.Value * rate;
        }

        var monthlyPlannedExpenseDtos = _mapper.MapToMonthlyPlannedExpenseDtos(monthlyPlannedExpenses);

        return new MonthlyPlannedExpensesDto
        {
            PlannedExpenses = monthlyPlannedExpenseDtos,
            Currency = targetCurrencyCode.Value.Value,
            TotalAmount = totalAmount
        };
    }

    public async Task<PlannedExpenseDto> CreateAsync(Guid userId, CreatePlannedExpenseDto createPlannedExpenseDto,
        CancellationToken cancellationToken = default)
    {
        var currencyCode = CurrencyCode.Create(createPlannedExpenseDto.Currency);

        var currency = await _unitOfWork.Currencies.GetByCurrencyCodeAsync(currencyCode.Value, cancellationToken);
        if (currency is null)
            throw new NotFoundException();

        var name = PlannedExpenseName.Create(createPlannedExpenseDto.Name);
        var amount = Money.Create(createPlannedExpenseDto.Amount);
        var createdAt = _timeProvider.GetUtcNow().UtcDateTime;

        var plannedExpense = PlannedExpense.Create(new UserId(userId), name.Value, amount.Value, currency.Id,
            createdAt);

        _unitOfWork.PlannedExpenses.Create(plannedExpense.Value);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map(plannedExpense.Value);
    }

    public async Task DeleteAsync(Guid userId, Guid plannedExpenseId, CancellationToken cancellationToken = default)
    {
        var plannedExpense =
            await _unitOfWork.PlannedExpenses.GetForUserAsync(new UserId(userId),
                new PlannedExpenseId(plannedExpenseId), cancellationToken)
            ?? throw new NotFoundException(nameof(plannedExpenseId), plannedExpenseId.ToString());

        _unitOfWork.PlannedExpenses.Delete(plannedExpense);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}