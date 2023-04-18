using Flow.Application.Models.Currency;

namespace Flow.Application.Models.PlannedExpense;

public sealed record PlannedExpenseDto(Guid Id, string Name, decimal Amount, CurrencyDto Currency, DateOnly ExpenseDate);