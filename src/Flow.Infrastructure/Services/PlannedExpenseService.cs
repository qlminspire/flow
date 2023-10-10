using AutoMapper;
using AutoMapper.QueryableExtensions;
using Flow.Application.Common;
using Flow.Application.Contracts.Persistence;
using Flow.Application.Contracts.Services;
using Flow.Application.Exceptions;
using Flow.Application.Models.PlannedExpense;
using Flow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flow.Infrastructure.Services;

internal sealed class PlannedExpenseService : IPlannedExpenseService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrencyConversionRateService _currencyConversionRateService;
    private readonly IMapper _mapper;
    private readonly IDateTimeProvider _dateTimeProvider;

    public PlannedExpenseService(IUnitOfWork unitOfWork, IMapper mapper, ICurrencyConversionRateService currencyConversionRateService, IDateTimeProvider dateTimeProvider)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _currencyConversionRateService = currencyConversionRateService;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<PlannedExpenseDto> GetAsync(Guid userId, Guid plannedExpenseId, CancellationToken cancellationToken = default)
    {
        var plannedExpense = await _unitOfWork.PlannedExpenses.GetByCondition(x => x.UserId == userId && x.Id == plannedExpenseId)
            .Include(x => x.Currency)
            .ProjectTo<PlannedExpenseDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);
        return plannedExpense ?? throw new NotFoundException(nameof(plannedExpenseId), plannedExpenseId.ToString());
    }

    public Task<List<PlannedExpenseDto>> GetAllAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.PlannedExpenses.GetByCondition(x => x.UserId == userId)
            .Include(x => x.Currency)
            .ProjectTo<PlannedExpenseDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }

    public async Task<MonthlyPlannedExpensesDto> GetAllForMonthAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        const string defaultCurrency = "USD";

        var currentDate = _dateTimeProvider.UtcNow;
        var startOfMonth = new DateOnly(currentDate.Year, currentDate.Month, 1);
        var plannedExpenses = await _unitOfWork.PlannedExpenses
            .GetByCondition(x => x.UserId == userId && x.ExpenseDate >= startOfMonth)
            .Include(x => x.Currency)
            .GroupBy(x => x.Currency.Code)
            .Select(x => new MonthlyPlannedExpenseDto
            {
                Currency = x.Key,
                Amount = x.Sum(z => z.Amount)
            })
            .ToListAsync(cancellationToken);

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
        var plannedExpense = _mapper.Map<PlannedExpense>(dto);
        plannedExpense.UserId = userId;

        _unitOfWork.PlannedExpenses.Create(plannedExpense);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var currency = await _unitOfWork.Currencies.GetByCondition(x => x.Id == dto.CurrencyId)
            .FirstOrDefaultAsync(CancellationToken.None);
        plannedExpense.Currency = currency;

        return _mapper.Map<PlannedExpenseDto>(plannedExpense);
    }

    public async Task UpdateAsync(Guid userId, Guid plannedExpenseId, UpdatePlannedExpenseDto dto, CancellationToken cancellationToken = default)
    {
        var plannedExpense = await _unitOfWork.PlannedExpenses.GetByCondition(x => x.UserId == userId && x.Id == plannedExpenseId, true)
            .FirstOrDefaultAsync(cancellationToken);
        if (plannedExpense == null)
            throw new NotFoundException(nameof(plannedExpenseId), plannedExpenseId.ToString());

        plannedExpense.Name = dto.Name;
        plannedExpense.Amount = dto.Amount;
        plannedExpense.CurrencyId = dto.CurrencyId;
        plannedExpense.ExpenseDate = dto.ExpenseDate;

        var currency = await _unitOfWork.Currencies.GetByCondition(x => x.Id == dto.CurrencyId)
            .FirstOrDefaultAsync(CancellationToken.None);
        plannedExpense.Currency = currency;

        _unitOfWork.PlannedExpenses.Update(plannedExpense);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid userId, Guid plannedExpenseId, CancellationToken cancellationToken = default)
    {
        var plannedExpense = await _unitOfWork.PlannedExpenses.GetByCondition(x => x.UserId == userId && x.Id == plannedExpenseId, true)
            .FirstOrDefaultAsync(cancellationToken);
        if (plannedExpense == null)
            throw new NotFoundException(nameof(plannedExpenseId), plannedExpenseId.ToString());

        _unitOfWork.PlannedExpenses.Delete(plannedExpense);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
