using Flow.Application.Models.PlannedExpense;
using Flow.Contracts.Requests.PlannedExpense;
using Flow.Contracts.Responses.PlannedExpense;
using Riok.Mapperly.Abstractions;

namespace Flow.Api.Mappings;

[Mapper]
internal partial class PlannedExpenseMapper
{
    public partial PlannedExpenseResponse Map(PlannedExpenseDto plannedExpenseDto);

    public partial ICollection<PlannedExpenseResponse> Map(ICollection<PlannedExpenseDto> plannedExpensesDto);

    public partial CreatePlannedExpenseDto Map(CreatePlannedExpenseRequest createPlannedExpenseRequest);

    public partial MonthlyPlannedExpensesResponse Map(MonthlyPlannedExpensesDto monthlyPlannedExpensesDto);

    public partial MonthlyPlannedExpense Map(MonthlyPlannedExpenseDto monthlyPlannedExpenseDto);
}