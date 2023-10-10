using AutoMapper;
using Flow.Application.Contracts.Persistence;
using Flow.Application.Contracts.Services;
using Flow.Application.Exceptions;
using Flow.Application.Models.BankAccount;
using Flow.Domain.Entities;

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
        var bankAccount = await _unitOfWork.BankAccounts.GetByIdAsync(accountId, cancellationToken)
            ?? throw new NotFoundException(nameof(accountId), accountId.ToString());
        return _mapper.Map<BankAccountDto>(bankAccount);
    }

    public async Task<List<BankAccountDto>> GetAllAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var banks = await _unitOfWork.BankAccounts.GetAsync(x => x.UserId == userId, cancellationToken);
        return _mapper.Map<List<BankAccountDto>>(banks);
    }

    public async Task<BankAccountDto> CreateAsync(Guid userId, CreateBankAccountDto createDto, CancellationToken cancellationToken = default)
    {
        var bankAccount = _mapper.Map<BankAccount>(createDto);
        bankAccount.UserId = userId;

        _unitOfWork.BankAccounts.Create(bankAccount);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var currency = await _unitOfWork.Currencies.GetByIdAsync(bankAccount.CurrencyId, CancellationToken.None);
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
