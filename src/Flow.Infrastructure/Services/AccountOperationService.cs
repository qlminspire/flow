using Flow.Application.Models.AccountOperation;
using Flow.Domain.AccountOperations;

namespace Flow.Infrastructure.Services;

internal sealed class AccountOperationService : IAccountOperationService
{
    private readonly AccountOperationMapper _mapper;
    private readonly TimeProvider _timeProvider;
    private readonly IUnitOfWork _unitOfWork;

    public AccountOperationService(IUnitOfWork unitOfWork, TimeProvider timeProvider)
    {
        ArgumentNullException.ThrowIfNull(unitOfWork);

        _unitOfWork = unitOfWork;
        _timeProvider = timeProvider;
        _mapper = new AccountOperationMapper();
    }

    public async Task<AccountOperationDto> GetAsync(Guid userId, Guid accountOperationId,
        CancellationToken cancellationToken = default)
    {
        var accountOperation =
            await _unitOfWork.AccountOperations.GetForUserAsync(userId, accountOperationId, cancellationToken);
        if (accountOperation is null)
            throw new NotFoundException(nameof(accountOperation), accountOperationId.ToString());

        return _mapper.Map(accountOperation);
    }

    public async Task<AccountOperationDto> CreateAsync(Guid userId, CreateAccountOperationDto createAccountOperationDto,
        CancellationToken cancellationToken = default)
    {
        var fromBankAccount = await
            _unitOfWork.Accounts.GetForUserAsync(userId, createAccountOperationDto.FromAccountId, cancellationToken);
        if (fromBankAccount is null)
            throw new ValidationException("Validation should be here");

        var toBankAccount = await
            _unitOfWork.Accounts.GetForUserAsync(userId, createAccountOperationDto.ToAccountId, cancellationToken);
        if (toBankAccount is null)
            throw new ValidationException("Validation should be here");

        var amount = Money.Create(createAccountOperationDto.Amount);
        var createdAt = _timeProvider.GetUtcNow().UtcDateTime;

        var accountOperation = AccountOperation.Create(fromBankAccount, toBankAccount, amount.Value, createdAt);

        var withdrawMoneyResult = fromBankAccount.WithdrawMoney(amount.Value);
        var addMoneyResult = toBankAccount.AddMoney(amount.Value);

        _unitOfWork.AccountOperations.Create(accountOperation.Value);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map(accountOperation.Value);
    }
}