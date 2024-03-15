using Flow.Application.Models.BankDeposit;
using Flow.Domain.BankDeposits;
using Flow.Domain.Currencies;
using Riok.Mapperly.Abstractions;

namespace Flow.Infrastructure.Mappings;

[Mapper]
internal partial class BankDepositMapper
{
    public partial BankDepositDto Map(BankDeposit bankDeposit);

    public partial List<BankDepositDto> Map(List<BankDeposit> bankDeposits);

    private decimal MoneyToDecimal(Money money) => money.Value;

    private string CurrencyToString(Currency currency) => currency.Code.Value;
}