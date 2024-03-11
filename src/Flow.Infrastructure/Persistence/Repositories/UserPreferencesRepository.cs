using Flow.Domain.UserPreferences;

namespace Flow.Infrastructure.Persistence.Repositories;

internal sealed class UserPreferencesRepository(FlowContext context)
    : BaseRepository<UserPreferences>(context), IUserPreferencesRepository;