using AutoMapper;

using Flow.Api.Models.BankAccount;
using Flow.Application.Models.BankAccount;

namespace Flow.Api.Mappings;

internal sealed class BankAccountProfile : Profile
{
    public BankAccountProfile()
    {
        CreateMap<BankAccountDto, BankAccountResponse>()
            .ForMember(dest => dest.Bank, opt => opt.MapFrom(src => src.Bank.Name))
            .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency.Code));
        CreateMap<CreateBankAccountRequest, CreateBankAccountDto>();
    }
}
