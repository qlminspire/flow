using Flow.Application.Models.BankDeposit;
using Flow.Domain.BankDeposits;
using Flow.Domain.Currencies;
using Riok.Mapperly.Abstractions;

namespace Flow.Infrastructure.Mappings;

[Mapper]
internal sealed partial class BankDepositMapper
{
    public partial BankDepositDto Map(BankDeposit bankDeposit);

    public partial List<BankDepositDto> Map(List<BankDeposit> bankDeposits);

    private static decimal MoneyToDecimal(Money money) => money.Value;

    private static string CurrencyToString(Currency currency) => currency.Code.Value;

    private static Guid IdToGuid(BankDepositId id) => id.Value;
}