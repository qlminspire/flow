﻿using Flow.Application.Models.UserCategory;

namespace Flow.Application.Contracts.Services;

public interface IUserCategoryService
{
    Task<UserCategoryDto> GetForUserAsync(Guid userId, Guid userCategoryId, CancellationToken cancellationToken = default);

    Task<List<UserCategoryDto>> GetAllForUserAsync(Guid userId, CancellationToken cancellationToken = default);

    Task<UserCategoryDto> CreateAsync(Guid userId, CreateUserCategoryDto createUserCategoryDto, CancellationToken cancellationToken = default);

    Task UpdateAsync(Guid userId, Guid userCategoryId, UpdateUserCategoryDto updateUserCategoryDto, CancellationToken cancellationToken = default);

    Task DeleteAsync(Guid userId, Guid userCategoryId, CancellationToken cancellationToken = default);
}