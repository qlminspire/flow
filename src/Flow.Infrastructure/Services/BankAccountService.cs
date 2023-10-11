using Flow.Application.Models.BankAccount;

namespace Flow.Infrastructure.Services;

internal sealed class BankAccountService : IBankAccountService
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly BankAccountMapper _mapper;

    public BankAccountService(IUnitOfWork unitOfWork)
    {
        ArgumentNullException.ThrowIfNull(unitOfWork, nameof(unitOfWork));

        _unitOfWork = unitOfWork;
        _mapper = new BankAccountMapper();
    }

    public async Task<BankAccountDto> GetAsync(Guid userId, Guid accountId, CancellationToken cancellationToken = default)
    {
        var bankAccount = await _unitOfWork.BankAccounts.GetByIdAsync(accountId, cancellationToken)
            ?? throw new NotFoundException(nameof(accountId), accountId.ToString());

        return _mapper.Map(bankAccount);
    }

    public async Task<List<BankAccountDto>> GetAllAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var banks = await _unitOfWork.BankAccounts.GetAsync(x => x.UserId == userId, cancellationToken);
        return _mapper.Map(banks);
    }

    public async Task<BankAccountDto> CreateAsync(Guid userId, CreateBankAccountDto createDto, CancellationToken cancellationToken = default)
    {
        var bankAccount = _mapper.Map(createDto);
        bankAccount.UserId = userId;

        _unitOfWork.BankAccounts.Create(bankAccount);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var currency = await _unitOfWork.Currencies.GetByIdAsync(bankAccount.CurrencyId, CancellationToken.None);
        bankAccount.Currency = currency;

        return _mapper.Map(bankAccount);
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
