namespace Flow.Application.Models.PlannedExpense;

public sealed class MonthlyPlannedExpensesDto
{
    public required ICollection<MonthlyPlannedExpenseDto> PlannedExpenses { get; init; }

    public required decimal TotalAmount { get; init; }

    public required string Currency { get; init; }
}