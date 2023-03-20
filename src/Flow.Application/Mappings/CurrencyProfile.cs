using AutoMapper;
using Flow.Application.Models.Currency;
using Flow.Domain.Entities;

namespace Flow.Application.Mappings;

internal sealed class CurrencyProfile : Profile
{
    public CurrencyProfile()
    {
        CreateMap<Currency, CurrencyDto>();
        CreateMap<CreateCurrencyDto, Currency>();
        CreateMap<UpdateCurrencyDto, Currency>();
    }
}
