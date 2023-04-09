using AutoMapper;
using AutoMapper.QueryableExtensions;
using Flow.Application.Common.Exceptions;
using Flow.Application.Models.BankAccount;
using Flow.Application.Persistence;
using Flow.Application.Services;
using Flow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flow.Infrastructure.Services;

internal sealed class BankAccountService : IBankAccountService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BankAccountService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BankAccountDto> GetAsync(Guid userId, Guid accountId, CancellationToken cancellationToken = default)
    {
        var bankAccount = await _unitOfWork.BankAccounts.GetByCondition(x => x.UserId == userId && x.Id == accountId, true)
            .Include(x => x.Bank)
            .Include(x => x.Currency)
            .ProjectTo<BankAccountDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);
        return bankAccount ?? throw new AccountNotFoundException(userId, accountId);
    }

    public Task<List<BankAccountDto>> GetAllAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.BankAccounts.GetByCondition(x => x.UserId == userId, false)
            .Include(x => x.Bank)
            .Include(x => x.Currency)
            .ProjectTo<BankAccountDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }

    public async Task<BankAccountDto> CreateAsync(Guid userId, CreateBankAccountDto createDto, CancellationToken cancellationToken = default)
    {
        var bankAccount = _mapper.Map<BankAccount>(createDto);
        bankAccount.UserId = userId;

        _unitOfWork.BankAccounts.Create(bankAccount);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var currency = await _unitOfWork.Currencies.GetByCondition(x => x.Id == bankAccount.CurrencyId)
            .FirstOrDefaultAsync(CancellationToken.None);
        bankAccount.Currency = currency;

        return _mapper.Map<BankAccountDto>(bankAccount);
    }

    public Task UpdateAsync(Guid userId, Guid accountId, UpdateBankAccountDto updateBankAccountDto, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task ArchiveAsync(Guid userId, Guid accountId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
