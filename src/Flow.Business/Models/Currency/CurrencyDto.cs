namespace Flow.Business.Models.Currency;

public sealed record CurrencyDto(Guid Id, string Code, string Name, bool IsActive);
