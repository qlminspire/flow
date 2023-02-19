namespace Flow.Api.Models.Currency;

public sealed record CreateCurrencyRequest(string Code, string Name, bool IsActive);
