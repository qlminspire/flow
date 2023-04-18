using Flow.Application.Persistence.Repositories;
using Flow.Domain.Entities;

namespace Flow.Infrastructure.Persistence.Repositories.Implementations;

internal sealed class UserPreferencesRepository : BaseRepository<UserPreferences>, IUserPreferencesRepository
{
    public UserPreferencesRepository(FlowContext context) : base(context)
    {
    }
}
