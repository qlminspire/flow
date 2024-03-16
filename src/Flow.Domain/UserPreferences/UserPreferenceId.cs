namespace Flow.Domain.UserPreferences;

public sealed record UserPreferenceId(Guid Value) : EntityId(Value);