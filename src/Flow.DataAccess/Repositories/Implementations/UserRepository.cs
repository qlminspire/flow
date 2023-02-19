using Flow.DataAccess.Contracts.Repositories;
using Flow.Entities;

namespace Flow.DataAccess.Repositories.Implementations;

internal sealed class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(FlowContext context) : base(context)
    {
    }
}
