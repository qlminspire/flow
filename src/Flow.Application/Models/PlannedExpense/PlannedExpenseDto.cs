namespace Flow.Application.Models.PlannedExpense;

public sealed record PlannedExpenseDto(Guid Id, string Name, decimal Amount, string Currency);