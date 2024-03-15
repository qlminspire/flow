using Flow.Domain.Accounts;

namespace Flow.Domain.AccountOperations;

public sealed class AccountOperation : Entity, IAuditable
{
    public AccountOperation(Guid id,
        Account fromAccount,
        Account toAccount,
        Money amount,
        DateTime createdAt)
        : base(id)
    {
        Amount = amount;
        FromAccountId = fromAccount.Id;
        ToAccountId = toAccount.Id;
        CreatedAt = createdAt;
    }

    private AccountOperation()
    {
    }

    public Money Amount { get; private set; }

    public Guid FromAccountId { get; private set; }

    public Account? FromAccount { get; private set; }

    public Guid ToAccountId { get; private set; }

    public Account? ToAccount { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime? UpdatedAt { get; private set; }

    public static Result<AccountOperation> Create(Account fromAccount, Account toAccount, Money money,
        DateTime date)
    {
        if (fromAccount.Id == toAccount.Id)
            return Result.Failure<AccountOperation>(AccountOperationErrors.SameSourceAndTargetAccount);

        if (fromAccount.IsDeactivated || toAccount.IsDeactivated)
            return Result.Failure<AccountOperation>(AccountOperationErrors.OneOfTheAccountsIsDeactivated);

        if (money.IsZero())
            return Result.Failure<AccountOperation>(AccountOperationErrors.ZeroAmount);

        var accountOperation = new AccountOperation(Guid.NewGuid(), fromAccount,
            toAccount, money, date);

        return accountOperation;
    }
}