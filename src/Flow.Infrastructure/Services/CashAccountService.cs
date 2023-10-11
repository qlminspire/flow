using Flow.Application.Models.CashAccount;

namespace Flow.Infrastructure.Services;

internal sealed class CashAccountService : ICashAccountService
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly CashAccountMapper _mapper;

    public CashAccountService(IUnitOfWork unitOfWork)
    {
        ArgumentNullException.ThrowIfNull(unitOfWork, nameof(unitOfWork));

        _unitOfWork = unitOfWork;
        _mapper = new CashAccountMapper();
    }

    public async Task<CashAccountDto> GetAsync(Guid userId, Guid accountId, CancellationToken cancellationToken = default)
    {
        var cashAccount = await _unitOfWork.CashAccounts.GetByIdAsync(accountId, cancellationToken)
            ?? throw new NotFoundException(nameof(accountId), accountId.ToString());

        return _mapper.Map(cashAccount);
    }

    public async Task<List<CashAccountDto>> GetAllAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var cashAccounts = await _unitOfWork.CashAccounts.GetAsync(x => x.UserId == userId, cancellationToken);
        return _mapper.Map(cashAccounts);
    }

    public async Task<CashAccountDto> CreateAsync(Guid userId, CreateCashAccountDto createDto, CancellationToken cancellationToken = default)
    {
        var cashAccount = _mapper.Map(createDto);
        cashAccount.UserId = userId;

        _unitOfWork.CashAccounts.Create(cashAccount);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var currency = await _unitOfWork.Currencies.GetByIdAsync(cashAccount.CurrencyId, CancellationToken.None);
        cashAccount.Currency = currency;

        return _mapper.Map(cashAccount);
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
