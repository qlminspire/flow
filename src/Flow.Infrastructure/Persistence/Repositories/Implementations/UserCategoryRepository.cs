using Flow.Application.Contracts.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Flow.Infrastructure.Persistence.Repositories.Implementations;

internal sealed class UserCategoryRepository : BaseRepository<UserCategory>, IUserCategoryRepository
{
    public UserCategoryRepository(FlowContext context) : base(context)
    {
    }

    public Task<UserCategory?> GetForUserAsync(Guid userId, Guid userCategoryId, CancellationToken cancellationToken = default)
    {
        return All
            .FirstOrDefaultAsync(x => x.UserId == userId && x.Id == userCategoryId, cancellationToken);
    }

    public Task<List<UserCategory>> GetAllForUserAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return All.AsNoTracking()
            .Where(x => x.UserId == userId)
            .ToListAsync(cancellationToken);
    }
}
