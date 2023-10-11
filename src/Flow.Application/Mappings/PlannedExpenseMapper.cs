using Flow.Application.Models.PlannedExpense;
using Riok.Mapperly.Abstractions;

namespace Flow.Application.Mappings;

[Mapper]
public partial class PlannedExpenseMapper
{
    public partial PlannedExpenseDto Map(PlannedExpense plannedExpense);

    public partial List<PlannedExpenseDto> Map(List<PlannedExpense> plannedExpense);

    public partial PlannedExpense Map(CreatePlannedExpenseDto createPlannedExpense);

    public partial void Map(PlannedExpense plannedExpense, UpdatePlannedExpenseDto updatePlannedExpense);
}
