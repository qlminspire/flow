using Flow.Application.Models.BankAccount;
using Flow.Domain.Accounts;
using Flow.Domain.Banks;
using Flow.Domain.Currencies;
using Flow.Domain.UserCategories;
using Riok.Mapperly.Abstractions;

namespace Flow.Infrastructure.Mappings;

[Mapper]
internal partial class BankAccountMapper
{
    public partial BankAccountDto Map(BankAccount bankAccount);

    public partial List<BankAccountDto> Map(List<BankAccount> bankAccounts);

    private static decimal MoneyToDecimal(Money money) => money.Value;

    private static string CurrencyToString(Currency currency) => currency.Code.Value;

    private static string AccountNameToString(AccountName accountName) => accountName.Value;

    private static string CategoryToString(UserCategory userCategory) => userCategory.Name.Value;

    private static string BankToString(Bank bank) => bank.Name.Value;

    private static string IbanToString(Iban iban) => iban.Value;

    private static Guid IdToGuid(AccountId id) => id.Value;
}