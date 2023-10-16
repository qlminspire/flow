using Flow.Application.Models.AccountOperation;

namespace Flow.Infrastructure.Services;

internal sealed class AccountOperationService : IAccountOperationService
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly AccountOperationMapper _mapper;

    public AccountOperationService(IUnitOfWork unitOfWork)
    {
        ArgumentNullException.ThrowIfNull(unitOfWork);

        _unitOfWork = unitOfWork;
        _mapper = new();
    }

    public async Task<AccountOperationDto> GetAsync(Guid userId, Guid operationId,
        CancellationToken cancellationToken = default)
    {
        var accountOperation =
            await _unitOfWork.AccountOperations.GetForUserAsync(userId, operationId, cancellationToken);
        if (accountOperation is null)
            throw new NotFoundException(nameof(accountOperation), operationId.ToString());

        return _mapper.Map(accountOperation);
    }

    public async Task<AccountOperationDto> CreateAsync(Guid userId, CreateAccountOperationDto createAccountOperationDto, CancellationToken cancellationToken = default)
    {
        var (fromAccountId, toAccountId, amount) = createAccountOperationDto;

        if (amount <= 0)
            throw new ValidationException("Validation should be here");

        if (fromAccountId == Guid.Empty || toAccountId == Guid.Empty)
            throw new ValidationException("Validation should be here");

        if (fromAccountId == toAccountId)
            throw new ValidationException("Validation should be here");

        var fromBankAccount = await
            _unitOfWork.Accounts.GetByIdAsync(fromAccountId, cancellationToken);
        if (fromBankAccount is null)
            throw new ValidationException("Validation should be here");

        var toBankAccount = await
            _unitOfWork.Accounts.GetByIdAsync(toAccountId, cancellationToken);
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
