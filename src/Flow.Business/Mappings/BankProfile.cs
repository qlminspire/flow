using AutoMapper;

using Flow.Business.Models.Bank;
using Flow.Entities;

namespace Flow.Business.Mappings;

internal sealed class BankProfile : Profile
{
    public BankProfile()
    {
        CreateMap<Bank, BankDto>();
        CreateMap<CreateBankDto, Bank>();
        CreateMap<UpdateBankDto, Bank>();
    }
}
