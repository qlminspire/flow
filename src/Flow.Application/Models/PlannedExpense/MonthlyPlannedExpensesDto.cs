namespace Flow.Application.Models.PlannedExpense;

public sealed class MonthlyPlannedExpensesDto
{
    public ICollection<MonthlyPlannedExpenseDto> PlannedExpenses { get; init; }

    public decimal TotalAmount { get; init; }

    public string Currency { get; init; }
}