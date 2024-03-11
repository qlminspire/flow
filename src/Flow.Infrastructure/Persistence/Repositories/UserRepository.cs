using Flow.Domain.Users;

namespace Flow.Infrastructure.Persistence.Repositories;

internal sealed class UserRepository(FlowContext context)
    : BaseRepository<User>(context), IUserRepository;