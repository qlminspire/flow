using AutoMapper;

using Flow.Business.Models.CashAccount;
using Flow.Entities;

namespace Flow.Business.Mappings;

internal sealed class CashAccountProfile: Profile
{
    public CashAccountProfile()
    {
        CreateMap<CashAccount, CashAccountDto>();
        CreateMap<CreateCashAccountDto, CashAccount>();
        CreateMap<UpdateCashAccountDto, CashAccount>();
    }
}
