using System.ComponentModel.DataAnnotations;

namespace Flow.Api.Contracts.Requests.PlannedExpense;

public sealed class CreatePlannedExpenseRequest
{
    public string Name { get; init; }

    [Required]
    public decimal Amount { get; init; }

    [Required]
    public Guid CurrencyId { get; init; }

    public DateTime ExpenseDate { get; init; }
}