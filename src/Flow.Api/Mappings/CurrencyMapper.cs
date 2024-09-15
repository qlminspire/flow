using Flow.Application.Models.Currency;
using Flow.Contracts.Requests.Currency;
using Flow.Contracts.Responses.Currency;
using Riok.Mapperly.Abstractions;

namespace Flow.Api.Mappings;

[Mapper]
internal sealed partial class CurrencyMapper
{
    public partial CurrencyResponse Map(CurrencyDto currencyDto);

    public partial ICollection<CurrencyResponse> Map(ICollection<CurrencyDto> currenciesDto);

    public partial CreateCurrencyDto Map(CreateCurrencyRequest createCurrencyRequest);
}