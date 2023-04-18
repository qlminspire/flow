using AutoMapper;
using Flow.Application.Models.BankDeposit;
using Flow.Domain.Entities;

namespace Flow.Application.Mappings;

internal class BankDepositProfile : Profile
{
    public BankDepositProfile()
    {
        CreateMap<BankDeposit, BankDepositDto>();
        CreateMap<CreateBankDepositDto, BankDeposit>();
        CreateMap<UpdateBankDepositDto, BankDeposit>();
    }
}
