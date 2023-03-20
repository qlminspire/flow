using AutoMapper;
using Flow.Application.Models.BankAccount;
using Flow.Domain.Entities;

namespace Flow.Application.Mappings;

internal sealed class BankAccountProfile : Profile
{
    public BankAccountProfile()
    {
        CreateMap<BankAccount, BankAccountDto>();
        CreateMap<CreateBankAccountDto, BankAccount>();
        CreateMap<UpdateBankAccountDto, BankAccount>();
    }
}
