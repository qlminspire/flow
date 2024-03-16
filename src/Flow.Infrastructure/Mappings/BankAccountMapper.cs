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

    private decimal MoneyToDecimal(Money money) => money.Value;

    private string CurrencyToString(Currency currency) => currency.Code.Value;

    private string AccountNameToString(AccountName accountName) => accountName.Value;

    private string CategoryToString(UserCategory userCategory) => userCategory.Name.Value;

    private string BankToString(Bank bank) => bank.Name.Value;

    private string IbanToString(Iban iban) => iban.Value;

    private Guid IdToGuid(AccountId id) => id.Value;
}