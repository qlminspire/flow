using Flow.Application.Models.BankAccount;
using Flow.Domain.Accounts;
using Flow.Domain.Banks;
using Flow.Domain.Currencies;
using Flow.Domain.UserCategories;
using Flow.Domain.Users;

namespace Flow.Infrastructure.Services;

internal sealed class BankAccountService : IBankAccountService
{
    private readonly BankAccountMapper _mapper;
    private readonly TimeProvider _timeProvider;
    private readonly IUnitOfWork _unitOfWork;

    public BankAccountService(IUnitOfWork unitOfWork, TimeProvider timeProvider)
    {
        _unitOfWork = unitOfWork;
        _timeProvider = timeProvider;
        _mapper = new BankAccountMapper();
    }

    public async Task<BankAccountDto> GetForUserAsync(Guid userId, Guid bankAccountId,
        CancellationToken cancellationToken = default)
    {
        var bankAccount =
            await _unitOfWork.BankAccounts.GetForUserAsync(new UserId(userId), new AccountId(bankAccountId),
                cancellationToken)
            ?? throw new NotFoundException(bankAccountId);

        return _mapper.Map(bankAccount);
    }

    public async Task<List<BankAccountDto>> GetAllForUserAsync(Guid userId,
        CancellationToken cancellationToken = default)
    {
        var banks = await _unitOfWork.BankAccounts.GetAllForUserAsync(new UserId(userId), cancellationToken);
        return _mapper.Map(banks);
    }

    public async Task<BankAccountDto> CreateAsync(Guid userId, CreateBankAccountDto createBankAccountDto,
        CancellationToken cancellationToken = default)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(new UserId(userId), cancellationToken);
        if (user is null)
            throw new NotFoundException(userId);

        var currencyCode = CurrencyCode.Create(createBankAccountDto.Currency);

        var currency = await _unitOfWork.Currencies.GetByCurrencyCodeAsync(currencyCode.Value, cancellationToken);
        if (currency is null)
            throw new NotFoundException();

        var bankId = new BankId(createBankAccountDto.BankId);
        var bank = await _unitOfWork.Banks.GetByIdAsync(bankId, cancellationToken);
        if (bank is null)
            throw new NotFoundException(bankId);

        var userCategory = createBankAccountDto.CategoryId.HasValue
            ? await _unitOfWork.UserCategories.GetForUserAsync(user.Id,
                new UserCategoryId(createBankAccountDto.CategoryId.Value), cancellationToken)
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

    public async Task DeleteAsync(Guid userId, Guid bankAccountId, CancellationToken cancellationToken = default)
    {
        var bankAccount =
            await _unitOfWork.CashAccounts.GetForUserAsync(new UserId(userId), new AccountId(bankAccountId),
                cancellationToken);
        if (bankAccount is null)
            throw new NotFoundException(bankAccountId);

        _unitOfWork.CashAccounts.Delete(bankAccount);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}