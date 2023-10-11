using Riok.Mapperly.Abstractions;

using Flow.Application.Models.Currency;

namespace Flow.Infrastructure.Mappings;

[Mapper]
internal partial class CurrencyMapper
{
    public partial CurrencyDto Map(Currency currency);

    public partial List<CurrencyDto> Map(List<Currency> currencies);

    public partial Currency Map(CreateCurrencyDto createCurrencyDto);

    public partial void Map(Currency currency, UpdateCurrencyDto updateCurrencyDto);
}
