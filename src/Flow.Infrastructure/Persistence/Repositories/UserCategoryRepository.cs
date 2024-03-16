using Flow.Domain.UserCategories;
using Flow.Domain.Users;

namespace Flow.Infrastructure.Persistence.Repositories;

internal sealed class UserCategoryRepository(FlowContext context)
    : BaseRepository<UserCategory, UserCategoryId>(context), IUserCategoryRepository
{
    public Task<UserCategory?> GetForUserAsync(UserId userId, UserCategoryId userCategoryId,
        CancellationToken cancellationToken = default)
    {
        return All
            .FirstOrDefaultAsync(x => x.UserId == userId && x.Id == userCategoryId, cancellationToken);
    }

    public Task<List<UserCategory>> GetAllForUserAsync(UserId userId, CancellationToken cancellationToken = default)
    {
        return All.AsNoTracking()
            .Where(x => x.UserId == userId)
            .ToListAsync(cancellationToken);
    }
}