using Flow.Application.Models.AccountOperation;

namespace Flow.Infrastructure.Services;

internal sealed class AccountOperationService : IAccountOperationService
{
    private readonly AccountOperationMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public AccountOperationService(IUnitOfWork unitOfWork)
    {
        ArgumentNullException.ThrowIfNull(unitOfWork);

        _unitOfWork = unitOfWork;
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
        var (fromAccountId, toAccountId, amount) = createAccountOperationDto;

        if (amount <= 0)
            throw new ValidationException("Validation should be here");

        if (fromAccountId == Guid.Empty || toAccountId == Guid.Empty)
            throw new ValidationException("Validation should be here");

        if (fromAccountId == toAccountId)
            throw new ValidationException("Validation should be here");

        var fromBankAccount = await
            _unitOfWork.Accounts.GetForUserAsync(userId, fromAccountId, cancellationToken);
        if (fromBankAccount is null)
            throw new ValidationException("Validation should be here");

        var toBankAccount = await
            _unitOfWork.Accounts.GetForUserAsync(userId, toAccountId, cancellationToken);
        if (toBankAccount is null)
            throw new ValidationException("Validation should be here");

        if (fromBankAccount.Amount < amount)
            throw new ValidationException("Validation should be here");

        var accountOperation = _mapper.Map(createAccountOperationDto);

        _unitOfWork.AccountOperations.Create(accountOperation);

        fromBankAccount.Amount -= accountOperation.Amount;
        toBankAccount.Amount += accountOperation.Amount;

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map(accountOperation);
    }
}