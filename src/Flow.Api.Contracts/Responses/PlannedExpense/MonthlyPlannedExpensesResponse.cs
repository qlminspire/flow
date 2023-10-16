namespace Flow.Api.Contracts.Responses.PlannedExpense;

public sealed class MonthlyPlannedExpensesResponse
{
    public ICollection<MonthlyPlannedExpense> PlannedExpenses { get; init; }

    public decimal TotalAmount { get; init; }

    public string Currency { get; init; }
}