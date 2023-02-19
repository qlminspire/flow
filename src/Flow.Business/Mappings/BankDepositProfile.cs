using AutoMapper;

using Flow.Business.Models.BankDeposit;
using Flow.Entities;

namespace Flow.Business.Mappings;

internal class BankDepositProfile: Profile
{
    public BankDepositProfile()
    {
        CreateMap<BankDeposit, BankDepositDto>()
            .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency!.Code));
        CreateMap<CreateBankDepositDto, BankDeposit>();
        CreateMap<UpdateBankDepositDto, BankDeposit>();
    }
}
