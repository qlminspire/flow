using AutoMapper;
using Flow.Api.Contracts.Requests.PlannedExpense;
using Flow.Api.Contracts.Responses.PlannedExpense;
using Flow.Application.Models.PlannedExpense;

namespace Flow.Api.Mappings;

internal sealed class PlannedExpenseProfile: Profile
{
    public PlannedExpenseProfile()
    {
        CreateMap<PlannedExpenseDto, PlannedExpenseResponse>()
            .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency.Code));
        CreateMap<CreatePlannedExpenseRequest, CreatePlannedExpenseDto>()
            .ForMember(dest => dest.ExpenseDate, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.ExpenseDate)));
        CreateMap<UpdatePlannedExpenseRequest, UpdatePlannedExpenseDto>()
            .ForMember(dest => dest.ExpenseDate, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.ExpenseDate)));

        CreateMap<MonthlyPlannedExpensesDto, MonthlyPlannedExpensesResponse>();
        CreateMap<MonthlyPlannedExpenseDto, MonthlyPlannedExpense>();
    }
}
