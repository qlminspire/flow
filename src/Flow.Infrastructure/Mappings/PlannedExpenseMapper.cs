using Riok.Mapperly.Abstractions;

using Flow.Application.Models.PlannedExpense;

namespace Flow.Infrastructure.Mappings;

[Mapper]
internal partial class PlannedExpenseMapper
{
    public partial PlannedExpenseDto Map(PlannedExpense plannedExpense);

    public partial List<PlannedExpenseDto> Map(List<PlannedExpense> plannedExpense);

    public partial PlannedExpense Map(CreatePlannedExpenseDto createPlannedExpense);

    public partial void Map(PlannedExpense plannedExpense, UpdatePlannedExpenseDto updatePlannedExpense);
}
