using Flow.Application.Models.CashAccount;
using Flow.Domain.Accounts;
using Flow.Domain.Currencies;

namespace Flow.Infrastructure.Services;

internal sealed class CashAccountService : ICashAccountService
{
    private readonly CashAccountMapper _mapper;
    private readonly TimeProvider _timeProvider;
    private readonly IUnitOfWork _unitOfWork;

    public CashAccountService(IUnitOfWork unitOfWork, TimeProvider timeProvider)
    {
        ArgumentNullException.ThrowIfNull(unitOfWork);

        _unitOfWork = unitOfWork;
        _timeProvider = timeProvider;
        _mapper = new CashAccountMapper();
    }

    public async Task<CashAccountDto> GetAsync(Guid userId, Guid cashAccountId,
        CancellationToken cancellationToken = default)
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

    public async Task<CashAccountDto> CreateAsync(Guid userId, CreateCashAccountDto createCashAccountDto,
        CancellationToken cancellationToken = default)
    {
        var currencyCode = CurrencyCode.Create(createCashAccountDto.Currency);

        var user = await _unitOfWork.Users.GetByIdAsync(userId, cancellationToken);
        if (user is null)
            throw new NotFoundException();

        var currency = await _unitOfWork.Currencies.GetByCurrencyCodeAsync(currencyCode.Value, cancellationToken);
        if (currency is null)
            throw new NotFoundException();

        var userCategory = createCashAccountDto.CategoryId.HasValue
            ? await _unitOfWork.UserCategories.GetForUserAsync(userId,
                createCashAccountDto.CategoryId.Value, cancellationToken)
            : null;

        var accountName = AccountName.Create(createCashAccountDto.Name);
        var amount = Money.Create(createCashAccountDto.Amount);
        var createdAt = _timeProvider.GetUtcNow().UtcDateTime;

        var cashAccount = CashAccount.Create(user, accountName.Value, amount.Value, currency,
            userCategory, createdAt);

        _unitOfWork.CashAccounts.Create(cashAccount.Value);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map(cashAccount.Value);
    }

    public async Task DeleteAsync(Guid userId, Guid cashAccountId, CancellationToken cancellationToken = default)
    {
        var cashAccount = await _unitOfWork.CashAccounts.GetForUserAsync(userId, cashAccountId, cancellationToken);
        if (cashAccount is null)
            throw new NotFoundException();

        _unitOfWork.CashAccounts.Delete(cashAccount);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}