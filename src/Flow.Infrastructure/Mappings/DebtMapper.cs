using Flow.Application.Models.Debt;
using Flow.Domain.Currencies;
using Flow.Domain.Debts;
using Riok.Mapperly.Abstractions;

namespace Flow.Infrastructure.Mappings;

[Mapper]
internal partial class DebtMapper
{
    public partial DebtDto Map(Debt debt);

    public partial List<DebtDto> Map(List<Debt> debts);

    private string DebtNameToString(DebtName debtName) => debtName.Value;

    private decimal MoneyToDecimal(Money money) => money.Value;

    private string CurrencyToString(Currency currency) => currency.Code.Value;
    
    private Guid IdToGuid(DebtId id) => id.Value;
}