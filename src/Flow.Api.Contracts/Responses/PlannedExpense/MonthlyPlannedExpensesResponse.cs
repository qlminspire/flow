namespace Flow.Api.Contracts.Responses.PlannedExpense;

public sealed class MonthlyPlannedExpensesResponse
{
    public ICollection<MonthlyPlannedExpense> PlannedExpenses { get; set; }

    public decimal TotalAmount { get; set; }

    public string Currency { get; set; }
}