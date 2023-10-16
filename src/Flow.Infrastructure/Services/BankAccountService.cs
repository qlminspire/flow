using Flow.Application.Models.BankAccount;

namespace Flow.Infrastructure.Services;

internal sealed class BankAccountService : IBankAccountService
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly BankAccountMapper _mapper;

    public BankAccountService(IUnitOfWork unitOfWork)
    {
        ArgumentNullException.ThrowIfNull(unitOfWork);

        _unitOfWork = unitOfWork;
        _mapper = new();
    }

    public async Task<BankAccountDto> GetForUserAsync(Guid userId, Guid bankAccountId, CancellationToken cancellationToken = default)
    {
        var bankAccount = await _unitOfWork.BankAccounts.GetForUserAsync(userId, bankAccountId, cancellationToken)
            ?? throw new NotFoundException(nameof(bankAccountId), bankAccountId.ToString());

        return _mapper.Map(bankAccount);
    }

    public async Task<List<BankAccountDto>> GetAllForUserAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var banks = await _unitOfWork.BankAccounts.GetAllForUserAsync(userId, cancellationToken);
        return _mapper.Map(banks);
    }

    public async Task<BankAccountDto> CreateAsync(Guid userId, CreateBankAccountDto createBankAccountDto, CancellationToken cancellationToken = default)
    {
        var currency = await _unitOfWork.Currencies.GetByIdAsync(createBankAccountDto.CurrencyId, cancellationToken);
        if (currency is null)
            throw new ValidationException("Validation not implemented.");

        var bank = await _unitOfWork.Banks.GetByIdAsync(createBankAccountDto.BankId, cancellationToken);
        if (bank is null)
            throw new ValidationException("Validation not implemented");

        if (createBankAccountDto.CategoryId.HasValue)
        {
            await _unitOfWork.UserCategories.GetForUserAsync(userId,
                createBankAccountDto.CategoryId.Value, cancellationToken);
        }

        var bankAccount = _mapper.Map(createBankAccountDto);
        bankAccount.UserId = userId;

        _unitOfWork.BankAccounts.Create(bankAccount);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map(bankAccount);
    }
}
