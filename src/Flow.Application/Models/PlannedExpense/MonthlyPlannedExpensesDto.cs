namespace Flow.Application.Models.PlannedExpense;

public sealed class MonthlyPlannedExpensesDto
{
    public ICollection<MonthlyPlannedExpenseDto> PlannedExpenses { get; set; }

    public decimal TotalAmount { get; set; }

    public string Currency { get; set; }
}
