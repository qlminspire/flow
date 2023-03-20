using AutoMapper;
using Flow.Application.Models.CashAccount;
using Flow.Domain.Entities;

namespace Flow.Application.Mappings;

internal sealed class CashAccountProfile : Profile
{
    public CashAccountProfile()
    {
        CreateMap<CashAccount, CashAccountDto>();
        CreateMap<CreateCashAccountDto, CashAccount>();
        CreateMap<UpdateCashAccountDto, CashAccount>();
    }
}
