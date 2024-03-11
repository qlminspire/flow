using Flow.Application.Models.UserCategory;

namespace Flow.Infrastructure.Services;

internal sealed class UserCategoryService : IUserCategoryService
{
    private readonly UserCategoryMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UserCategoryService(IUnitOfWork unitOfWork)
    {
        ArgumentNullException.ThrowIfNull(unitOfWork);

        _unitOfWork = unitOfWork;

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
        var userCategory = _mapper.Map(createUserCategoryDto);
        userCategory.UserId = userId;

        _unitOfWork.UserCategories.Create(userCategory);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map(userCategory);
    }

    public async Task UpdateAsync(Guid userId, Guid userCategoryId, UpdateUserCategoryDto updateUserCategoryDto,
        CancellationToken cancellationToken = default)
    {
        var userCategory = await _unitOfWork.UserCategories.GetForUserAsync(userId, userCategoryId, cancellationToken)
                           ?? throw new NotFoundException();

        _mapper.Map(updateUserCategoryDto, userCategory);

        _unitOfWork.UserCategories.Update(userCategory);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid userId, Guid userCategoryId, CancellationToken cancellationToken = default)
    {
        var userCategory = await _unitOfWork.UserCategories.GetForUserAsync(userId, userCategoryId, cancellationToken)
                           ?? throw new NotFoundException();

        _unitOfWork.UserCategories.Delete(userCategory);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}