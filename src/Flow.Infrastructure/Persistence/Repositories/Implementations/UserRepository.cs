using Flow.Application.Contracts.Persistence.Repositories;
using Flow.Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;

namespace Flow.Infrastructure.Persistence.Repositories.Implementations;

internal sealed class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(FlowContext context) : base(context)
    {
    }

    public Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return All.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
    }
}
