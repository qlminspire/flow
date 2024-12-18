﻿using Microsoft.AspNetCore.Mvc;

using Flow.Api.Contracts.Requests.UserCategory;
using Flow.Api.Contracts.Responses.UserCategory;

namespace Flow.Api.Controllers;

public class UserCategoriesController : BaseController
{
    private readonly IUserCategoryService _userCategoryService;
    private readonly UserCategoryMapper _mapper;

    public UserCategoriesController(IUserCategoryService userCategoryService)
    {
        _userCategoryService = userCategoryService;
        _mapper = new();
    }

    /// <summary>
    /// Get user category
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET: api/userCategories/69128754-e11b-4b59-bef4-d2a2588a374f
    /// </remarks>
    /// <param name="id">The Id of the user category</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The user category</returns>
    [HttpGet("{id:guid}", Name = "GetUserCategory")]
    [ProducesResponseType(typeof(UserCategoryResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status404NotFound)]
    public async Task<IResult> GetUserCategoryAsync(Guid id, CancellationToken cancellationToken)
    {
        var userCategory = await _userCategoryService.GetForUserAsync(UserId, id, cancellationToken);
        return Results.Ok(_mapper.Map(userCategory));
    }

    /// <summary>
    /// Get all user categories for user
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET: api/userCategories
    /// </remarks>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The list of all user categories</returns>
    [HttpGet]
    [ProducesResponseType(typeof(ICollection<UserCategoryResponse>), StatusCodes.Status200OK)]
    public async Task<IResult> GetUserCategoriesAsync(CancellationToken cancellationToken)
    {
        var userCategories = await _userCategoryService.GetAllForUserAsync(UserId, cancellationToken);
        return Results.Ok(_mapper.Map(userCategories));
    }

    /// <summary>
    /// Create user category
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST: api/userCategories
    ///     {
    ///         "name": "Жилье",
    ///         "description": "Вложения в жилье"
    ///     }
    /// </remarks>
    /// <param name="request">The create user category request</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The newly created user category</returns>
    [HttpPost]
    [ProducesResponseType(typeof(UserCategoryResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status404NotFound)]
    public async Task<IResult> CreateUserCategoryAsync([FromBody] CreateUserCategoryRequest request, CancellationToken cancellationToken)
    {
        var createUserCategoryDto = _mapper.Map(request);
        var category = await _userCategoryService.CreateAsync(UserId, createUserCategoryDto, cancellationToken);
        var response = _mapper.Map(category);
        return Results.CreatedAtRoute("GetUserCategory", new { response.Id }, response);
    }

    /// <summary>
    /// Update user category
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     PUT: api/userCategories/888db9d1-30e3-4190-a654-7d17a5bbb545
    ///     {
    ///         "name": "Жильё"
    ///     }
    /// </remarks>
    /// <param name="id">The Id of the user category</param>
    /// <param name="request">The update user category request</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns></returns>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status404NotFound)]
    public async Task<IResult> UpdateUserCategoryAsync(Guid id, [FromBody] UpdateUserCategoryRequest request, CancellationToken cancellationToken)
    {
        var updateUserCategoryDto = _mapper.Map(request);
        await _userCategoryService.UpdateAsync(UserId, id, updateUserCategoryDto, cancellationToken);
        return Results.NoContent();
    }

    /// <summary>
    /// Delete user category
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     DELETE: api/userCategories/105c8926-d5dc-43e7-9792-8702e43cd128
    /// </remarks>
    /// <param name="id">The Id of the user category</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns></returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status404NotFound)]
    public async Task<IResult> DeleteUserCategoryAsync(Guid id, CancellationToken cancellationToken)
    {
        await _userCategoryService.DeleteAsync(UserId, id, cancellationToken);
        return Results.NoContent();
    }
}
