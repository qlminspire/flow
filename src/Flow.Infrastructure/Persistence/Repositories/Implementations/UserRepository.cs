using Flow.Application.Contracts.Persistence.Repositories;
using Flow.Domain.Entities.Auth;

namespace Flow.Infrastructure.Persistence.Repositories.Implementations;

internal sealed class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(FlowContext context) : base(context)
    {
    }
}
