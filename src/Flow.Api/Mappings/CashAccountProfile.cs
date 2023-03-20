using AutoMapper;

using Flow.Api.Models.CashAccount;
using Flow.Application.Models.CashAccount;

namespace Flow.Api.Mappings;

internal sealed class CashAccountProfile : Profile
{
    public CashAccountProfile()
    {
        CreateMap<CashAccountDto, CashAccountResponse>()
            .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency.Code));
        CreateMap<CreateCashAccountRequest, CreateCashAccountDto>();
    }
}
