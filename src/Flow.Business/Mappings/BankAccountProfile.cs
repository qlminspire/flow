using AutoMapper;

using Flow.Business.Models.BankAccount;
using Flow.Entities;

namespace Flow.Business.Mappings;

internal sealed class BankAccountProfile: Profile
{
    public BankAccountProfile()
    {
        CreateMap<BankAccount, BankAccountDto>();
        CreateMap<CreateBankAccountDto, BankAccount>();
        CreateMap<UpdateBankAccountDto, BankAccount>();
    }
}
