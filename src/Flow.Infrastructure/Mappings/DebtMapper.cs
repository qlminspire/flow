using Flow.Application.Models.Debt;
using Flow.Domain.Currencies;
using Flow.Domain.Debts;
using Riok.Mapperly.Abstractions;

namespace Flow.Infrastructure.Mappings;

[Mapper]
internal sealed partial class DebtMapper
{
    public partial DebtDto Map(Debt debt);

    public partial List<DebtDto> Map(List<Debt> debts);

    private static string DebtNameToString(DebtName debtName) => debtName.Value;

    private static decimal MoneyToDecimal(Money money) => money.Value;

    private static string CurrencyToString(Currency currency) => currency.Code.Value;

    private static Guid IdToGuid(DebtId id) => id.Value;
}