using Flow.Application.Models.UserCategory;
using Flow.Domain.UserCategories;
using Riok.Mapperly.Abstractions;

namespace Flow.Infrastructure.Mappings;

[Mapper]
internal partial class UserCategoryMapper
{
    public partial UserCategoryDto Map(UserCategory userCategory);

    public partial List<UserCategoryDto> Map(List<UserCategory> userCategories);

    private string UserCategoryNameToString(UserCategoryName userCategoryName) => userCategoryName.Value;

    private Guid IdToGuid(UserCategoryId id) => id.Value;
}