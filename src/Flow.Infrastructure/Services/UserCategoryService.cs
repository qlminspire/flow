using Flow.Application.Models.UserCategory;
using Flow.Domain.UserCategories;
using Flow.Domain.Users;

namespace Flow.Infrastructure.Services;

internal sealed class UserCategoryService : IUserCategoryService
{
    private readonly UserCategoryMapper _mapper;
    private readonly TimeProvider _timeProvider;
    private readonly IUnitOfWork _unitOfWork;

    public UserCategoryService(IUnitOfWork unitOfWork, TimeProvider timeProvider)
    {
        _unitOfWork = unitOfWork;
        _timeProvider = timeProvider;

        _mapper = new UserCategoryMapper();
    }

    public async Task<UserCategoryDto> GetForUserAsync(Guid userId, Guid userCategoryId,
        CancellationToken cancellationToken = default)
    {
        var userCategory =
            await _unitOfWork.UserCategories.GetForUserAsync(new UserId(userId), new UserCategoryId(userCategoryId),
                cancellationToken)
            ?? throw new NotFoundException(userCategoryId);
        return _mapper.Map(userCategory);
    }

    public async Task<List<UserCategoryDto>> GetAllForUserAsync(Guid userId,
        CancellationToken cancellationToken = default)
    {
        var userCategories = await _unitOfWork.UserCategories.GetAllForUserAsync(new UserId(userId), cancellationToken);
        return _mapper.Map(userCategories);
    }

    public async Task<UserCategoryDto> CreateAsync(Guid userId, CreateUserCategoryDto createUserCategoryDto,
        CancellationToken cancellationToken = default)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(new UserId(userId), cancellationToken);
        if (user is null)
            throw new NotFoundException();

        var userCategoryName = UserCategoryName.Create(createUserCategoryDto.Name);
        var createdAt = _timeProvider.GetUtcNow().UtcDateTime;

        var userCategory = UserCategory.Create(user, userCategoryName.Value, createdAt);

        _unitOfWork.UserCategories.Create(userCategory.Value);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map(userCategory.Value);
    }

    public async Task DeleteAsync(Guid userId, Guid userCategoryId, CancellationToken cancellationToken = default)
    {
        var userCategory =
            await _unitOfWork.UserCategories.GetForUserAsync(new UserId(userId), new UserCategoryId(userCategoryId),
                cancellationToken)
            ?? throw new NotFoundException(userCategoryId);

        _unitOfWork.UserCategories.Delete(userCategory);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}