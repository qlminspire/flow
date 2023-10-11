using Flow.Application.Models.PlannedExpense;
using Flow.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Flow.Application.Mapperly;

[Mapper]
public partial class PlannedExpenseMapper
{
    public partial PlannedExpenseDto Map(PlannedExpense plannedExpense);

    public partial List<PlannedExpenseDto> Map(List<PlannedExpense> plannedExpense);

    public partial PlannedExpense Map(CreatePlannedExpenseDto createPlannedExpense);

    public partial void Map(PlannedExpense plannedExpense, UpdatePlannedExpenseDto updatePlannedExpense);
}
