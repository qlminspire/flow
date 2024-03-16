namespace Flow.Domain.Currencies;

public sealed record CurrencyId(Guid Value) : EntityId(Value);