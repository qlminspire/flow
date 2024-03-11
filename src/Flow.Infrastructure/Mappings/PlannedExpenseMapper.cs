using Flow.Application.Models.PlannedExpense;
using Flow.Domain.PlannedExpenses;
using Riok.Mapperly.Abstractions;

namespace Flow.Infrastructure.Mappings;

[Mapper]
internal partial class PlannedExpenseMapper
{
    public partial PlannedExpenseDto Map(PlannedExpense plannedExpense);

    public partial List<PlannedExpenseDto> Map(List<PlannedExpense> plannedExpense);

    public partial PlannedExpense Map(CreatePlannedExpenseDto createPlannedExpense);

    public partial void Map(UpdatePlannedExpenseDto updatePlannedExpense, PlannedExpense plannedExpense);
}