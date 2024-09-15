using Flow.Application.Models.CashAccount;
using Flow.Domain.Accounts;
using Flow.Domain.Currencies;
using Flow.Domain.UserCategories;
using Riok.Mapperly.Abstractions;

namespace Flow.Infrastructure.Mappings;

[Mapper]
internal sealed partial class CashAccountMapper
{
    public partial CashAccountDto Map(CashAccount cashAccount);

    public partial List<CashAccountDto> Map(List<CashAccount> cashAccounts);

    private static decimal MoneyToDecimal(Money money) => money.Value;

    private static string CurrencyToString(Currency currency) => currency.Code.Value;

    private static string AccountNameToString(AccountName accountName) => accountName.Value;

    private static string CategoryToString(UserCategory userCategory) => userCategory.Name.Value;

    private static Guid IdToGuid(AccountId id) => id.Value;
}