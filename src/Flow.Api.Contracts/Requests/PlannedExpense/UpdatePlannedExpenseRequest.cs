﻿namespace Flow.Api.Contracts.Requests.PlannedExpense;

public sealed class UpdatePlannedExpenseRequest
{
    public string Name { get; init; }

    public decimal Amount { get; init; }

    public Guid CurrencyId { get; init; }

    public DateTime ExpenseDate { get; init; }
}