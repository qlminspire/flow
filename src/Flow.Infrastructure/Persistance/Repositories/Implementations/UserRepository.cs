using Flow.Application.Persistance.Repositories;
using Flow.Domain.Entities;
using Flow.Infrastructure.Persistance;

namespace Flow.Infrastructure.Persistance.Repositories.Implementations;

internal sealed class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(FlowContext context) : base(context)
    {
    }
}
