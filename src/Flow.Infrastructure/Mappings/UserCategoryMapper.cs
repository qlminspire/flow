﻿using Flow.Application.Models.UserCategory;
using Flow.Domain.UserCategories;
using Riok.Mapperly.Abstractions;

namespace Flow.Infrastructure.Mappings;

[Mapper]
internal partial class UserCategoryMapper
{
    public partial UserCategoryDto Map(UserCategory userCategory);

    public partial List<UserCategoryDto> Map(List<UserCategory> userCategories);

    public partial UserCategory Map(CreateUserCategoryDto createUserCategoryDto);

    public partial void Map(UpdateUserCategoryDto updateUserCategoryDto, UserCategory userCategory);
}