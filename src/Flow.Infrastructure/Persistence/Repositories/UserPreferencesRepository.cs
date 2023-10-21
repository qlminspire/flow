namespace Flow.Infrastructure.Persistence.Repositories;

internal sealed class UserPreferencesRepository : BaseRepository<UserPreferences>, IUserPreferencesRepository
{
    public UserPreferencesRepository(FlowContext context) : base(context)
    {
    }
}
