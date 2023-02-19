namespace Flow.Api.Models.Currency;

public sealed record UpdateCurrencyRequest(string Code, string Name, bool? IsActive);
