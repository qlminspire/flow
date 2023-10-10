using Microsoft.EntityFrameworkCore;

using Flow.Application.Models.Balance;
using Flow.Application.Contracts.Services;
using Flow.Application.Contracts.Persistence;

namespace Flow.Infrastructure.Services;

internal sealed class CalculatedBalanceService : ICalculatedBalanceService
{
    private readonly IUnitOfWork _unitOfWork;

    public CalculatedBalanceService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CalculatedBalanceDto> GetAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var bankAccountsTotalBalance = await _unitOfWork.BankAccounts.GetByCondition(x => x.UserId == userId)
            .Include(x => x.Currency)
            .GroupBy(x => x.Currency!.Code)
            .Select(x => new BalanceDto
            {
                Currency = x.Key,
                Amount = x.Sum(y => y.Amount)
            }).ToListAsync(cancellationToken);

        var cashAccountsTotalBalance = await _unitOfWork.CashAccounts.GetByCondition(x => x.UserId == userId)
            .Include(x => x.Currency)
            .GroupBy(x => x.Currency!.Code)
            .Select(x => new BalanceDto
            {
                Currency = x.Key,
                Amount = x.Sum(y => y.Amount)
            }).ToListAsync(cancellationToken);

        var depositsTotalBalance = await _unitOfWork.BankDeposits.GetByCondition(x => x.UserId == userId)
            .Include(x => x.Currency)
            .GroupBy(x => x.Currency!.Code)
            .Select(x => new BalanceDto
            {
                Currency = x.Key,
                Amount = x.Sum(y => y.Amount)
            }).ToListAsync(cancellationToken);

        var debtsTotalBalance = await _unitOfWork.Debts.GetByCondition(x => x.UserId == userId)
            .Include(x => x.Currency)
            .GroupBy(x => x.Currency.Code)
            .Select(x => new BalanceDto
            {
                Currency = x.Key,
                Amount = x.Sum(y => y.Amount)
            }).ToListAsync(cancellationToken);

        return new CalculatedBalanceDto
        {
            TotalBankAccounts = bankAccountsTotalBalance,
            TotalCashAccounts = cashAccountsTotalBalance,
            TotalDeposits = depositsTotalBalance,
            TotalDebts = debtsTotalBalance
        };
    }
}
