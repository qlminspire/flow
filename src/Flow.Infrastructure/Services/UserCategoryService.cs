﻿using Flow.Application.Models.UserCategory;
using Flow.Domain.UserCategories;

namespace Flow.Infrastructure.Services;

internal sealed class UserCategoryService : IUserCategoryService
{
    private readonly UserCategoryMapper _mapper;
    private readonly TimeProvider _timeProvider;
    private readonly IUnitOfWork _unitOfWork;

    public UserCategoryService(IUnitOfWork unitOfWork, TimeProvider timeProvider)
    {
        ArgumentNullException.ThrowIfNull(unitOfWork);

        _unitOfWork = unitOfWork;
        _timeProvider = timeProvider;

        _mapper = new UserCategoryMapper();
    }

    public async Task<UserCategoryDto> GetForUserAsync(Guid userId, Guid userCategoryId,
        CancellationToken cancellationToken = default)
    {
        var userCategory = await _unitOfWork.UserCategories.GetForUserAsync(userId, userCategoryId, cancellationToken)
                           ?? throw new NotFoundException();
        return _mapper.Map(userCategory);
    }

    public async Task<List<UserCategoryDto>> GetAllForUserAsync(Guid userId,
        CancellationToken cancellationToken = default)
    {
        var userCategories = await _unitOfWork.UserCategories.GetAllForUserAsync(userId, cancellationToken);
        return _mapper.Map(userCategories);
    }

    public async Task<UserCategoryDto> CreateAsync(Guid userId, CreateUserCategoryDto createUserCategoryDto,
        CancellationToken cancellationToken = default)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(userId, cancellationToken);

        var userCategoryName = UserCategoryName.Create(createUserCategoryDto.Name);
        var createdAt = _timeProvider.GetUtcNow().UtcDateTime;

        var userCategory = UserCategory.Create(user, userCategoryName.Value, createdAt);

        _unitOfWork.UserCategories.Create(userCategory.Value);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map(userCategory.Value);
    }

    public async Task DeleteAsync(Guid userId, Guid userCategoryId, CancellationToken cancellationToken = default)
    {
        var userCategory = await _unitOfWork.UserCategories.GetForUserAsync(userId, userCategoryId, cancellationToken)
                           ?? throw new NotFoundException();

        _unitOfWork.UserCategories.Delete(userCategory);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}