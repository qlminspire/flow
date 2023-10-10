using AutoMapper;
using Flow.Api.Contracts.Requests.BankDeposit;
using Flow.Api.Contracts.Responses.BankDeposit;
using Flow.Application.Models.BankDeposit;

namespace Flow.Api.Mappings;

internal sealed class BankDepositProfile : Profile
{
    public BankDepositProfile()
    {
        CreateMap<BankDepositDto, BankDepositResponse>()
            .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency.Code));
        CreateMap<CreateBankDepositRequest, CreateBankDepositDto>();
    }
}
