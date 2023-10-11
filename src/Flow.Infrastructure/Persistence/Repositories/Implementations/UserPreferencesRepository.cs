using Flow.Application.Contracts.Persistence.Repositories;

namespace Flow.Infrastructure.Persistence.Repositories.Implementations;

internal sealed class UserPreferencesRepository : BaseRepository<UserPreferences>, IUserPreferencesRepository
{
    public UserPreferencesRepository(FlowContext context) : base(context)
    {
    }
}
