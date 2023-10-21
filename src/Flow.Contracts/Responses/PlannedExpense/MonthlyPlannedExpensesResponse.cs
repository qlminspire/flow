namespace Flow.Contracts.Responses.PlannedExpense;

public sealed class MonthlyPlannedExpensesResponse
{
    public required ICollection<MonthlyPlannedExpense> PlannedExpenses { get; init; }

    public required decimal TotalAmount { get; init; }

    public required string Currency { get; init; }
}