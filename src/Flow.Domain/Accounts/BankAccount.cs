using Flow.Domain.BankDeposits;
using Flow.Domain.Banks;
using Flow.Domain.Currencies;
using Flow.Domain.UserCategories;
using Flow.Domain.Users;

namespace Flow.Domain.Accounts;

public sealed class BankAccount : Account
{
    public BankAccount(
        AccountId id,
        AccountName name,
        Money balance,
        Currency currency,
        User user,
        Bank bank,
        Iban iban,
        UserCategory? category,
        DateTime createdAt)
        : base(id, name, balance, currency, user, category, createdAt)
    {
        BankId = bank.Id;
        Iban = iban;
    }

    private BankAccount()
    {
    }

    public Iban Iban { get; private set; }

    public BankId BankId { get; private set; }

    public Bank? Bank { get; private set; }

    public ICollection<BankDeposit> Deposits { get; private set; }

    public static Result<BankAccount> Create(User user, AccountName name, Money amount, Currency currency, Bank bank,
        Iban iban,
        UserCategory? category, DateTime createdAt)
    {
        return new BankAccount(new AccountId(Guid.NewGuid()), name, amount, currency, user, bank, iban, category,
            createdAt);
    }
}