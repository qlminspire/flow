namespace Flow.Api.Models.Currency;

public sealed record CurrencyResponse(Guid Id, string Code, string Name, bool IsActive);