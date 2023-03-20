using AutoMapper;
using Flow.Application.Models.BankDeposit;
using Flow.Domain.Entities;

namespace Flow.Application.Mappings;

internal class BankDepositProfile : Profile
{
    public BankDepositProfile()
    {
        CreateMap<BankDeposit, BankDepositDto>()
            .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency!.Code));
        CreateMap<CreateBankDepositDto, BankDeposit>();
        CreateMap<UpdateBankDepositDto, BankDeposit>();
    }
}
