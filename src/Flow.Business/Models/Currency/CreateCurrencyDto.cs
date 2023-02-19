namespace Flow.Business.Models.Currency;

public sealed record CreateCurrencyDto(string Name, string Code, bool IsActive);