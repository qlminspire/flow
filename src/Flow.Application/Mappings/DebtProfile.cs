using AutoMapper;
using Flow.Application.Models.Debt;
using Flow.Domain.Entities;

namespace Flow.Application.Mappings;

internal sealed class DebtProfile : Profile
{
    public DebtProfile()
    {
        CreateMap<Debt, DebtDto>();
        CreateMap<CreateDebtDto, Debt>();
        CreateMap<UpdateDebtDto, Debt>();
    }
}
