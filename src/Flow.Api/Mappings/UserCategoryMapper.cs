using Flow.Application.Models.UserCategory;
using Flow.Contracts.Requests.UserCategory;
using Flow.Contracts.Responses.UserCategory;
using Riok.Mapperly.Abstractions;

namespace Flow.Api.Mappings;

[Mapper]
internal sealed partial class UserCategoryMapper
{
    public partial UserCategoryResponse Map(UserCategoryDto userCategoryDto);

    public partial ICollection<UserCategoryResponse> Map(ICollection<UserCategoryDto> userCategoriesDto);

    public partial CreateUserCategoryDto Map(CreateUserCategoryRequest createUserCategoryRequest);
}