using AutoMapper;

using Flow.Api.Models.Balance;
using Flow.Business.Models.Balance;

namespace Flow.Api.Mappings;

internal sealed class BalanceProfile : Profile
{
    public BalanceProfile()
    {
        CreateMap<BalanceDto, BalanceResponse>();
        CreateMap<CalculatedBalanceDto, CalculatedBalanceResponse>();
    }
}
