using AutoMapper;

using Flow.Api.Models.BankDeposit;
using Flow.Application.Models.BankDeposit;

namespace Flow.Api.Mappings;

internal sealed class BankDepositProfile : Profile
{
    public BankDepositProfile()
    {
        CreateMap<BankDepositDto, BankDepositResponse>();
        CreateMap<CreateBankDepositRequest, CreateBankDepositDto>();
    }
}
