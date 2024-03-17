using Flow.Application.Models.AccountOperation;
using Flow.Domain.AccountOperations;
using Flow.Domain.Accounts;
using Flow.Domain.Users;

namespace Flow.Infrastructure.Services;

internal sealed class AccountOperationService : IAccountOperationService
{
    private readonly AccountOperationMapper _mapper;
    private readonly TimeProvider _timeProvider;
    private readonly IUnitOfWork _unitOfWork;

    public AccountOperationService(IUnitOfWork unitOfWork, TimeProvider timeProvider)
    {
        _unitOfWork = unitOfWork;
        _timeProvider = timeProvider;
        _mapper = new AccountOperationMapper();
    }

    public async Task<AccountOperationDto> GetAsync(Guid userId, Guid accountOperationId,
        CancellationToken cancellationToken = default)
    {
        var accountOperation = await _unitOfWork.AccountOperations.GetForUserAsync(new UserId(userId),
            new AccountOperationId(accountOperationId), cancellationToken);
        if (accountOperation is null)
            throw new NotFoundException(accountOperationId);

        return _mapper.Map(accountOperation);
    }

    public async Task<AccountOperationDto> CreateAsync(Guid userId, CreateAccountOperationDto createAccountOperationDto,
        CancellationToken cancellationToken = default)
    {
        var fromAccountId = new AccountId(createAccountOperationDto.FromAccountId);
        var fromAccount = await
            _unitOfWork.Accounts.GetForUserAsync(new UserId(userId), fromAccountId, cancellationToken);
        if (fromAccount is null)
            throw new NotFoundException(fromAccountId);

        var toAccountId = new AccountId(createAccountOperationDto.ToAccountId);
        var toAccount = await
            _unitOfWork.Accounts.GetForUserAsync(new UserId(userId), toAccountId, cancellationToken);
        if (toAccount is null)
            throw new NotFoundException(toAccountId);

        var amount = Money.Create(createAccountOperationDto.Amount);
        var createdAt = _timeProvider.GetUtcNow().UtcDateTime;

        var accountOperation = AccountOperation.Create(fromAccount, toAccount, amount.Value, createdAt);

        var withdrawMoneyResult = fromAccount.Withdraw(amount.Value, createdAt);
        var addMoneyResult = toAccount.Deposit(amount.Value, createdAt);

        _unitOfWork.AccountOperations.Create(accountOperation.Value);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map(accountOperation.Value);
    }
}