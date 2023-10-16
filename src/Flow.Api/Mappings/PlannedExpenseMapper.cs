using Riok.Mapperly.Abstractions;

using Flow.Api.Contracts.Requests.PlannedExpense;
using Flow.Api.Contracts.Responses.PlannedExpense;

using Flow.Application.Models.PlannedExpense;

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
