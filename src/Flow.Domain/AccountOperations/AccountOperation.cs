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

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public static Result<AccountOperation> Create(Account fromAccount, Account toAccount, Money amount,
        DateTime createdAt)
    {
        // if (amount <= 0)
        //     throw new ValidationException("Validation should be here");
        //
        // if (fromAccountId == Guid.Empty || toAccountId == Guid.Empty)
        //     throw new ValidationException("Validation should be here");
        //
        // if (fromAccountId == toAccountId)
        //     throw new ValidationException("Validation should be here");

        // if (fromBankAccount.Amount < amount)
        //     throw new ValidationException("Validation should be here");

        return new AccountOperation(Guid.NewGuid(), fromAccount, toAccount, amount, createdAt);
    }
}