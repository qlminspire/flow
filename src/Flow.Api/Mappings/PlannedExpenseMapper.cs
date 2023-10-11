using Riok.Mapperly.Abstractions;

using Flow.Api.Contracts.Requests.PlannedExpense;
using Flow.Api.Contracts.Responses.PlannedExpense;

using Flow.Application.Models.PlannedExpense;

namespace Flow.Api.Mappings;

[Mapper]
internal partial class PlannedExpenseMapper
{
    public partial PlannedExpenseResponse Map(PlannedExpenseDto plannedExpenseDto);
    // .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency.Code));

    public partial ICollection<PlannedExpenseResponse> Map(ICollection<PlannedExpenseDto> plannedExpensesDto);

    public partial CreatePlannedExpenseDto Map(CreatePlannedExpenseRequest createPlannedExpenseRequest);
    // .ForMember(dest => dest.ExpenseDate, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.ExpenseDate)));
    public partial UpdatePlannedExpenseDto Map(UpdatePlannedExpenseRequest updatePlannedExpenseRequest);
    // .ForMember(dest => dest.ExpenseDate, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.ExpenseDate)));

    public partial MonthlyPlannedExpensesResponse Map(MonthlyPlannedExpensesDto monthlyPlannedExpensesDto);

    public partial MonthlyPlannedExpense Map(MonthlyPlannedExpenseDto monthlyPlannedExpenseDto);
}
