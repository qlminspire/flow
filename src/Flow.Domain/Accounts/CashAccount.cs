using Flow.Domain.Currencies;
using Flow.Domain.UserCategories;
using Flow.Domain.Users;

namespace Flow.Domain.Accounts;

public sealed class CashAccount : Account
{
    private CashAccount(
        Guid id,
        AccountName name,
        Money balance,
        Currency currency,
        User user,
        UserCategory? category,
        DateTime createdAt)
        : base(id, name, balance, currency, user, category, createdAt)
    {
    }

    private CashAccount()
    {
    }

    public static Result<CashAccount> Create(User user, AccountName name, Money amount, Currency currency,
        UserCategory? category, DateTime createdAt)
    {
        return new CashAccount(Guid.NewGuid(), name, amount, currency, user, category, createdAt);
    }
}