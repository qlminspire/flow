using Flow.Domain.Currencies;
using Flow.Domain.UserCategories;
using Flow.Domain.Users;

namespace Flow.Domain.Accounts;

public abstract class Account : Entity<AccountId>, IAuditable, IDeactivatable
{
    protected Account(
        AccountId id,
        AccountName name,
        Money balance,
        Currency currency,
        User user,
        UserCategory? category,
        DateTime createdAt)
        : base(id)
    {
        Name = name;
        Balance = balance;
        CurrencyId = currency.Id;
        UserId = user.Id;
        CategoryId = category?.Id;
        CreatedAt = createdAt;
    }

    protected Account()
    {
    }

    public AccountName Name { get; private set; }

    public Money Balance { get; private set; }

    public CurrencyId CurrencyId { get; private set; }

    public Currency? Currency { get; private set; }

    public UserId UserId { get; private set; }

    public User? User { get; private set; }

    public UserCategoryId? CategoryId { get; private set; }

    public UserCategory? Category { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime? UpdatedAt { get; private set; }

    public bool IsDeactivated { get; }

    public DateTime? DeactivatedAt { get; }

    public Result Deposit(Money money, DateTime date)
    {
        if (IsDeactivated)
            return Result.Failure(AccountErrors.Deactivated);

        Balance += money;
        UpdatedAt = date;

        return Result.Success();
    }

    public Result Withdraw(Money money, DateTime date)
    {
        if (IsDeactivated)
            return Result.Failure(AccountErrors.Deactivated);

        if (Balance <= money)
            return Result.Failure(AccountErrors.NotEnoughMoney);

        Balance -= money;
        UpdatedAt = date;

        return Result.Success();
    }
}