using AutoMapper;
using AutoMapper.QueryableExtensions;
using Flow.Business.Models.CashAccount;
using Flow.DataAccess.Contracts;
using Flow.Entities;
using Flow.Entities.Core.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Flow.Business.Services.Implementations;

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

    public Task ArchiveAsync(Guid userId, Guid accoutId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
