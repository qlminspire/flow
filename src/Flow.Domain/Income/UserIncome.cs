using Flow.Domain.Accounts;

namespace Flow.Domain.Income;

public sealed class UserIncome : Entity, IAuditable
{
    private UserIncome(
        Guid id,
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

    public Guid AccountId { get; private set; }

    public Account? Account { get; private set; }

    public DateTimeOffset? Date { get; private set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public static Result<UserIncome> Create(Money amount, IncomeSource source, Account account, DateTime? date,
        DateTime createdAt)
    {
        return new UserIncome(Guid.NewGuid(), amount, source, account, date, createdAt);
    }
}