using AutoMapper;
using Flow.Api.Contracts.Requests.Currency;
using Flow.Api.Contracts.Responses.Currency;
using Flow.Application.Models.Currency;

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
