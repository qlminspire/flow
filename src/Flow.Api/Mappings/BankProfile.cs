using AutoMapper;

using Flow.Api.Models.Bank;

using Flow.Application.Models.Bank;

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
