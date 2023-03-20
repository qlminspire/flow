using AutoMapper;
using Flow.Application.Models.Bank;
using Flow.Domain.Entities;

namespace Flow.Application.Mappings;

internal sealed class BankProfile : Profile
{
    public BankProfile()
    {
        CreateMap<Bank, BankDto>();
        CreateMap<CreateBankDto, Bank>();
        CreateMap<UpdateBankDto, Bank>();
    }
}
