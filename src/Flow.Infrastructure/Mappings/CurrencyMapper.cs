using Flow.Application.Models.Currency;
using Flow.Domain.Currencies;
using Riok.Mapperly.Abstractions;

namespace Flow.Infrastructure.Mappings;

[Mapper]
internal sealed partial class CurrencyMapper
{
    public partial CurrencyDto Map(Currency currency);

    public partial List<CurrencyDto> Map(List<Currency> currencies);

    private static string CurrencyCodeToString(CurrencyCode currencyCode) => currencyCode.Value;

    private static Guid IdToGuid(CurrencyId id) => id.Value;
}