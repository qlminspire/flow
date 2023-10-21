using Flow.Api.Contracts.Responses.Currency;

namespace Flow.Api.Contracts.Responses.PlannedExpense;

public sealed class PlannedExpenseResponse
{
    public required Guid Id { get; init; }

    public required string Name { get; set; }

    public required decimal Amount { get; init; }

    public required CurrencyShortResponse Currency { get; init; }
}