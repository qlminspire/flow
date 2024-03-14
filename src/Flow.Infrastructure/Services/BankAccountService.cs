using Flow.Application.Models.BankAccount;
using Flow.Domain.Accounts;
using Flow.Domain.Currencies;

namespace Flow.Infrastructure.Services;

internal sealed class BankAccountService : IBankAccountService
{
    private readonly BankAccountMapper _mapper;
    private readonly TimeProvider _timeProvider;
    private readonly IUnitOfWork _unitOfWork;

    public BankAccountService(IUnitOfWork unitOfWork, TimeProvider timeProvider)
    {
        ArgumentNullException.ThrowIfNull(unitOfWork);

        _unitOfWork = unitOfWork;
        _timeProvider = timeProvider;
        _mapper = new BankAccountMapper();
    }

    public async Task<BankAccountDto> GetForUserAsync(Guid userId, Guid bankAccountId,
        CancellationToken cancellationToken = default)
    {
        var bankAccount = await _unitOfWork.BankAccounts.GetForUserAsync(userId, bankAccountId, cancellationToken)
                          ?? throw new NotFoundException(nameof(bankAccountId), bankAccountId.ToString());

        return _mapper.Map(bankAccount);
    }

    public async Task<List<BankAccountDto>> GetAllForUserAsync(Guid userId,
        CancellationToken cancellationToken = default)
    {
        var banks = await _unitOfWork.BankAccounts.GetAllForUserAsync(userId, cancellationToken);
        return _mapper.Map(banks);
    }

    public async Task<BankAccountDto> CreateAsync(Guid userId, CreateBankAccountDto createBankAccountDto,
        CancellationToken cancellationToken = default)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(userId, cancellationToken);
        if (user is null)
            throw new ValidationException("Validation not implemented.");

        var currencyCode = CurrencyCode.Create(createBankAccountDto.Currency);
        var currency = await _unitOfWork.Currencies.GetByCurrencyCodeAsync(currencyCode.Value, cancellationToken);
        if (currency is null)
            throw new ValidationException("Validation not implemented.");

        var bank = await _unitOfWork.Banks.GetByIdAsync(createBankAccountDto.BankId, cancellationToken);
        if (bank is null)
            throw new ValidationException("Validation not implemented");

        var userCategory = createBankAccountDto.CategoryId.HasValue
            ? await _unitOfWork.UserCategories.GetForUserAsync(userId,
                createBankAccountDto.CategoryId.Value, cancellationToken)
            : null;

        var accountName = AccountName.Create(createBankAccountDto.Name);
        var iban = Iban.Create(createBankAccountDto.Iban);
        var amount = Money.Create(createBankAccountDto.Amount);
        var createdAt = _timeProvider.GetUtcNow().UtcDateTime;

        var bankAccount = BankAccount.Create(user, accountName.Value, amount.Value, currency, bank, iban.Value,
            userCategory, createdAt);

        _unitOfWork.BankAccounts.Create(bankAccount.Value);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map(bankAccount.Value);
    }
}