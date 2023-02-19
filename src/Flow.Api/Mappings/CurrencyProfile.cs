using AutoMapper;

using Flow.Api.Models.Currency;
using Flow.Business.Models.Currency;

namespace Flow.Api.Mappings;

internal sealed class CurrencyProfile : Profile
{
    public CurrencyProfile()
    {
        CreateMap<CurrencyDto, CurrencyResponse>();
        CreateMap<CreateCurrencyRequest, CreateCurrencyDto>();
        CreateMap<UpdateCurrencyRequest, UpdateCurrencyDto>();
    }
}
