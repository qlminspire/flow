using AutoMapper;
using Flow.Application.Models.PlannedExpense;
using Flow.Domain.Entities;

namespace Flow.Application.Mappings;

internal sealed class PlannedExpenseProfile : Profile
{
    public PlannedExpenseProfile()
    {
        CreateMap<PlannedExpense, PlannedExpenseDto>();
        CreateMap<CreatePlannedExpenseDto, PlannedExpense>();
        CreateMap<UpdatePlannedExpenseDto, PlannedExpense>();
    }
}
