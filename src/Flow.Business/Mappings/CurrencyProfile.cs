using AutoMapper;

using Flow.Business.Models.Currency;
using Flow.Entities;

namespace Flow.Business.Mappings;

internal sealed class CurrencyProfile: Profile
{
    public CurrencyProfile()
    {
        CreateMap<Currency, CurrencyDto>();    
        CreateMap<CreateCurrencyDto, Currency>();
        CreateMap<UpdateCurrencyDto, Currency>();
    }
}
