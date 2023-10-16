using Flow.Application.Models.PlannedExpense;

namespace Flow.Infrastructure.Services;

internal sealed class PlannedExpenseService : IPlannedExpenseService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrencyConversionRateService _currencyConversionRateService;
    private readonly TimeProvider _timeProvider;

    private readonly PlannedExpenseMapper _mapper;

    public PlannedExpenseService(IUnitOfWork unitOfWork, ICurrencyConversionRateService currencyConversionRateService, TimeProvider timeProvider)
    {
        ArgumentNullException.ThrowIfNull(unitOfWork);

        _unitOfWork = unitOfWork;
        _currencyConversionRateService = currencyConversionRateService;
        _timeProvider = timeProvider;

        _mapper = new();
    }

    public async Task<PlannedExpenseDto> GetAsync(Guid userId, Guid plannedExpenseId, CancellationToken cancellationToken = default)
    {
        var plannedExpense = await _unitOfWork.PlannedExpenses.GetForUserAsync(userId, plannedExpenseId, cancellationToken)
            ?? throw new NotFoundException(nameof(plannedExpenseId), plannedExpenseId.ToString());

        return _mapper.Map(plannedExpense);
    }

    public async Task<List<PlannedExpenseDto>> GetAllAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var plannedExpenses = await _unitOfWork.PlannedExpenses.GetAllForUserAsync(userId, cancellationToken);
        return _mapper.Map(plannedExpenses);
    }

    public async Task<MonthlyPlannedExpensesDto> GetAllForMonthAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        const string defaultCurrency = "USD";

        var currentDate = _timeProvider.GetUtcNow();
        var startOfMonth = new DateOnly(currentDate.Year, currentDate.Month, 1);
        var plannedExpenses = await _unitOfWork.PlannedExpenses.GetAggregatedByCurrencyAsync(userId, startOfMonth, cancellationToken);

        decimal totalAmount = 0;
        foreach (var expense in plannedExpenses)
        {
            var rate = _currencyConversionRateService.GetConversionRate(expense.Currency, defaultCurrency);
            totalAmount += expense.Amount * rate;
        }

        return new MonthlyPlannedExpensesDto
        {
            PlannedExpenses = plannedExpenses,
            Currency = defaultCurrency,
            TotalAmount = totalAmount
        };
    }

    public async Task<PlannedExpenseDto> CreateAsync(Guid userId, CreatePlannedExpenseDto dto, CancellationToken cancellationToken = default)
    {
        var currency = await _unitOfWork.Currencies.GetByIdAsync(dto.CurrencyId, cancellationToken);
        if (currency is null)
            throw new ValidationException();

        var plannedExpense = _mapper.Map(dto);
        plannedExpense.UserId = userId;

        _unitOfWork.PlannedExpenses.Create(plannedExpense);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map(plannedExpense);
    }

    public async Task UpdateAsync(Guid userId, Guid plannedExpenseId, UpdatePlannedExpenseDto updatePlannedExpenseDto, CancellationToken cancellationToken = default)
    {
        var currency = await _unitOfWork.Currencies.GetByIdAsync(updatePlannedExpenseDto.CurrencyId, cancellationToken);
        if (currency is null)
            throw new ValidationException();

        var plannedExpense = await _unitOfWork.PlannedExpenses.GetForUserAsync(userId, plannedExpenseId, cancellationToken)
            ?? throw new NotFoundException(nameof(plannedExpenseId), plannedExpenseId.ToString());

        _mapper.Map(updatePlannedExpenseDto, plannedExpense);

        _unitOfWork.PlannedExpenses.Update(plannedExpense);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid userId, Guid plannedExpenseId, CancellationToken cancellationToken = default)
    {
        var plannedExpense = await _unitOfWork.PlannedExpenses.GetForUserAsync(userId, plannedExpenseId, cancellationToken)
            ?? throw new NotFoundException(nameof(plannedExpenseId), plannedExpenseId.ToString());

        _unitOfWork.PlannedExpenses.Delete(plannedExpense);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
