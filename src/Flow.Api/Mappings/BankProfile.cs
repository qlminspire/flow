using AutoMapper;

using Flow.Api.Models.Bank;
using Flow.Business.Models.Bank;

namespace Flow.Api.Mappings;

internal sealed class BankProfile : Profile
{
    public BankProfile()
    {
        CreateMap<BankDto, BankResponse>();
        CreateMap<CreateBankRequest, CreateBankDto>();
        CreateMap<UpdateBankRequest, UpdateBankDto>();
    }
}
