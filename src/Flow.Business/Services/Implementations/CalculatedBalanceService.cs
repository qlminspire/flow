using Microsoft.EntityFrameworkCore;

using Flow.Business.Models.Balance;
using Flow.DataAccess.Contracts;

namespace Flow.Business.Services.Implementations;

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
                Amount = x.Sum(x => x.Amount)
            }).ToListAsync(cancellationToken);

        var cashAccountsTotalBalance = await _unitOfWork.CashAccounts.GetByCondition(x => x.UserId == userId)
            .Include(x => x.Currency)
            .GroupBy(x => x.Currency!.Code)
            .Select(x => new BalanceDto
            {
                Currency = x.Key,
                Amount = x.Sum(x => x.Amount)
            }).ToListAsync(cancellationToken);

        return new CalculatedBalanceDto
        {
            TotalBankAccounts = bankAccountsTotalBalance,
            TotalCashAccounts = cashAccountsTotalBalance
        };
    }
}
