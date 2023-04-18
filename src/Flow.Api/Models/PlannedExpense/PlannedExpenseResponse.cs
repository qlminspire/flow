namespace Flow.Api.Models.PlannedExpense;

public sealed class PlannedExpenseResponse
{
    public Guid Id { get; init; }

    public string Name { get; set; }

    public decimal Amount { get; init; }

    public string Currency { get; init; }

    public DateOnly ExpenseDate { get; init; }
}