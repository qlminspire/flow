using Flow.Application.Models.Currency;
using Flow.Application.Models.UserCategory;

namespace Flow.Application.Models.CashAccount;

public sealed class CashAccountDto
{
    public Guid Id { get; init; }

    public string Name { get; init; }

    public decimal Amount { get; init; }

    public CurrencyDto Currency { get; init; }

    public UserCategoryDto? Category { get; init; }
}
