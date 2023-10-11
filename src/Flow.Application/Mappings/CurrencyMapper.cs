using Flow.Application.Models.Currency;
using Flow.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Flow.Application.Mapperly;

[Mapper]
public partial class CurrencyMapper
{
    public partial CurrencyDto Map(Currency currency);

    public partial List<CurrencyDto> Map(List<Currency> currencies);

    public partial Currency Map(CreateCurrencyDto createCurrencyDto);

    public partial void Map(Currency currency, UpdateCurrencyDto updateCurrencyDto);
}
