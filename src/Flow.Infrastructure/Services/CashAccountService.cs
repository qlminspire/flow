using Flow.Application.Models.CashAccount;

namespace Flow.Infrastructure.Services;

internal sealed class CashAccountService : ICashAccountService
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly CashAccountMapper _mapper;

    public CashAccountService(IUnitOfWork unitOfWork)
    {
        ArgumentNullException.ThrowIfNull(unitOfWork);

        _unitOfWork = unitOfWork;
        _mapper = new();
    }

    public async Task<CashAccountDto> GetAsync(Guid userId, Guid cashAccountId, CancellationToken cancellationToken = default)
    {
        var cashAccount = await _unitOfWork.CashAccounts.GetForUserAsync(userId, cashAccountId, cancellationToken)
            ?? throw new NotFoundException(nameof(cashAccountId), cashAccountId.ToString());

        return _mapper.Map(cashAccount);
    }

    public async Task<List<CashAccountDto>> GetAllAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var cashAccounts = await _unitOfWork.CashAccounts.GetAllForUserAsync(userId, cancellationToken);
        return _mapper.Map(cashAccounts);
    }

    public async Task<CashAccountDto> CreateAsync(Guid userId, CreateCashAccountDto createCashAccountDto, CancellationToken cancellationToken = default)
    {
        var currency = await _unitOfWork.Currencies.GetByIdAsync(createCashAccountDto.CurrencyId, cancellationToken);
        if (currency is null)
            throw new ValidationException();

        var cashAccount = _mapper.Map(createCashAccountDto);
        cashAccount.UserId = userId;

        _unitOfWork.CashAccounts.Create(cashAccount);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map(cashAccount);
    }
}
