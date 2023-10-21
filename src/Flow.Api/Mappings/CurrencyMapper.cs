using Riok.Mapperly.Abstractions;
using Flow.Application.Models.Currency;
using Flow.Contracts.Requests.Currency;
using Flow.Contracts.Responses.Currency;

namespace Flow.Api.Mappings;

[Mapper]
internal partial class CurrencyMapper
{
    public partial CurrencyShortResponse MapToCurrencyShortResponse(CurrencyDto currencyDto);

    public partial CurrencyResponse Map(CurrencyDto currencyDto);

    public partial ICollection<CurrencyResponse> Map(ICollection<CurrencyDto> currenciesDto);

    public partial CreateCurrencyDto Map(CreateCurrencyRequest createCurrencyRequest);

    public partial UpdateCurrencyDto Map(UpdateCurrencyRequest updateCurrencyRequest);
}
