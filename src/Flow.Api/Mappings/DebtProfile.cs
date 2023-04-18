using AutoMapper;
using Flow.Api.Models.Debt;
using Flow.Application.Models.Debt;

namespace Flow.Api.Mappings;

internal sealed class DebtProfile : Profile
{
    public DebtProfile()
    {
        CreateMap<DebtDto, DebtResponse>()
            .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency.Code));
        CreateMap<CreateDebtRequest, CreateDebtDto>();
    }
}
