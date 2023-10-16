using Flow.Api.Contracts.Responses.Currency;

namespace Flow.Api.Contracts.Responses.PlannedExpense;

public sealed class PlannedExpenseResponse
{
    public Guid Id { get; init; }

    public string Name { get; set; }

    public decimal Amount { get; init; }

    public CurrencyShortResponse Currency { get; init; }
}