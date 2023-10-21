using Riok.Mapperly.Abstractions;
using Flow.Application.Models.PlannedExpense;
using Flow.Contracts.Requests.PlannedExpense;
using Flow.Contracts.Responses.PlannedExpense;

namespace Flow.Api.Mappings;

[Mapper]
internal partial class PlannedExpenseMapper
{
    public partial PlannedExpenseResponse Map(PlannedExpenseDto plannedExpenseDto);

    public partial ICollection<PlannedExpenseResponse> Map(ICollection<PlannedExpenseDto> plannedExpensesDto);

    public partial CreatePlannedExpenseDto Map(CreatePlannedExpenseRequest createPlannedExpenseRequest);

    public partial UpdatePlannedExpenseDto Map(UpdatePlannedExpenseRequest updatePlannedExpenseRequest);

    public partial MonthlyPlannedExpensesResponse Map(MonthlyPlannedExpensesDto monthlyPlannedExpensesDto);

    public partial MonthlyPlannedExpense Map(MonthlyPlannedExpenseDto monthlyPlannedExpenseDto);
}
