using Flow.Application.Models.CashAccount;
using Flow.Domain.Accounts;
using Flow.Domain.Currencies;
using Flow.Domain.UserCategories;
using Riok.Mapperly.Abstractions;

namespace Flow.Infrastructure.Mappings;

[Mapper]
internal partial class CashAccountMapper
{
    public partial CashAccountDto Map(CashAccount cashAccount);

    public partial List<CashAccountDto> Map(List<CashAccount> cashAccounts);

    private decimal MoneyToDecimal(Money money) => money.Value;

    private string CurrencyToString(Currency currency) => currency.Code.Value;

    private string AccountNameToString(AccountName accountName) => accountName.Value;

    private string CategoryToString(UserCategory userCategory) => userCategory.Name.Value;

    private Guid IdToGuid(AccountId id) => id.Value;
}