using Riok.Mapperly.Abstractions;

using Flow.Api.Contracts.Requests.Currency;
using Flow.Api.Contracts.Responses.Currency;
using Flow.Application.Models.Currency;

namespace Flow.Api.Mappings;

[Mapper]
internal partial class CurrencyMapper
{
    public partial CurrencyResponse Map(CurrencyDto currencyDto);

    public partial ICollection<CurrencyResponse> Map(ICollection<CurrencyDto> currenciesDto);

    public partial CreateCurrencyDto Map(CreateCurrencyRequest createCurrencyRequest);

    public partial UpdateCurrencyDto Map(UpdateCurrencyRequest updateCurrencyRequest);
}
