using Flow.Domain.Users;

namespace Flow.Domain.UserCategories;

public interface IUserCategoryRepository : IRepository<UserCategory, UserCategoryId>
{
    Task<UserCategory?> GetForUserAsync(UserId userId, UserCategoryId userCategoryId,
        CancellationToken cancellationToken = default);

    Task<List<UserCategory>> GetAllForUserAsync(UserId userId, CancellationToken cancellationToken = default);
}