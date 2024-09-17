using Flow.Domain.Currencies;
using Flow.Domain.Users;

namespace Flow.Domain.UserPreferences;

public sealed class UserPreferences : Entity<UserPreferenceId>, IAuditable
{
    private UserPreferences(
        UserPreferenceId id,
        User user,
        Currency currency,
        DateTime createdAt)
        : base(id)
    {
        UserId = user.Id;
        CurrencyId = currency.Id;
        CreatedAt = createdAt;
    }

    private UserPreferences()
    {
    }

    public CurrencyId CurrencyId { get; private set; }

    public Currency? Currency { get; private set; }

    public UserId UserId { get; private set; }

    public User? User { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime? UpdatedAt { get; private set; }

    public static Result<UserPreferences> Create(User user, Currency currency, DateTime createdAt)
    {
        return new UserPreferences(new UserPreferenceId(Guid.NewGuid()), user, currency, createdAt);
    }
}