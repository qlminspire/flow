using Flow.Domain.Accounts;

namespace Flow.Domain.Income;

public sealed class UserIncome : Entity<UserIncomeId>, IAuditable
{
    private UserIncome(
        UserIncomeId id,
        Money amount,
        IncomeSource source,
        Account account,
        DateTime? date,
        DateTime createdAt
    ) : base(id)
    {
        Amount = amount;
        Source = source;
        AccountId = account.Id;
        Date = date;
        CreatedAt = createdAt;
    }

    private UserIncome()
    {
    }

    public Money Amount { get; private set; }

    public IncomeSource Source { get; private set; }

    public AccountId AccountId { get; private set; }

    public Account? Account { get; private set; }

    public DateTimeOffset? Date { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime? UpdatedAt { get; private set; }

    public static Result<UserIncome> Create(Money amount, IncomeSource source, Account account, DateTime? date,
        DateTime createdAt)
    {
        return new UserIncome(new UserIncomeId(Guid.NewGuid()), amount, source, account, date, createdAt);
    }
}