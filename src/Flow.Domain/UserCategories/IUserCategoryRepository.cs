﻿namespace Flow.Domain.UserCategories;

public interface IUserCategoryRepository : IRepository<UserCategory>
{
    Task<UserCategory?> GetForUserAsync(Guid userId, Guid userCategoryId,
        CancellationToken cancellationToken = default);

    Task<List<UserCategory>> GetAllForUserAsync(Guid userId, CancellationToken cancellationToken = default);
}