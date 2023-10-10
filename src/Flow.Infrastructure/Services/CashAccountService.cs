using AutoMapper;
using AutoMapper.QueryableExtensions;
using Flow.Application.Common.Exceptions;
using Flow.Application.Contracts.Persistence;
using Flow.Application.Contracts.Services;
using Flow.Application.Models.CashAccount;
using Flow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flow.Infrastructure.Services;

internal sealed class CashAccountService : ICashAccountService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CashAccountService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CashAccountDto> GetAsync(Guid userId, Guid accountId, CancellationToken cancellationToken = default)
    {
        var cashAccount = await _unitOfWork.CashAccounts.GetByCondition(x => x.UserId == userId && x.Id == accountId, true)
            .Include(x => x.Currency)
            .ProjectTo<CashAccountDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);
        return cashAccount ?? throw new AccountNotFoundException(userId, accountId);
    }

    public Task<List<CashAccountDto>> GetAllAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.CashAccounts.GetByCondition(x => x.UserId == userId, false)
            .Include(x => x.Currency)
            .ProjectTo<CashAccountDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }

    public async Task<CashAccountDto> CreateAsync(Guid userId, CreateCashAccountDto createDto, CancellationToken cancellationToken = default)
    {
        var cashAccount = _mapper.Map<CashAccount>(createDto);
        cashAccount.UserId = userId;

        _unitOfWork.CashAccounts.Create(cashAccount);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var currency = await _unitOfWork.Currencies.GetByCondition(x => x.Id == cashAccount.CurrencyId, false)
            .FirstOrDefaultAsync(CancellationToken.None);
        cashAccount.Currency = currency;

        return _mapper.Map<CashAccountDto>(cashAccount);
    }

    public Task UpdateAsync(Guid userId, Guid accountId, UpdateCashAccountDto updateCashAccountDto, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task ArchiveAsync(Guid userId, Guid accountId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
