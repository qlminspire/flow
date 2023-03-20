namespace Flow.Application.Models.Currency;

public sealed record UpdateCurrencyDto(string Name, string Code, bool? IsActive);