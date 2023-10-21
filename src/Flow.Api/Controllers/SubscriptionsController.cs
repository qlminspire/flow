using Flow.Contracts.Requests.Subscription;
using Flow.Contracts.Responses.Subscription;
using Microsoft.AspNetCore.Mvc;

namespace Flow.Api.Controllers;

public class SubscriptionsController : BaseController
{
    private readonly ISubscriptionService _subscriptionService;
    private readonly SubscriptionMapper _mapper;

    public SubscriptionsController(ISubscriptionService subscriptionService)
    {
        _subscriptionService = subscriptionService;
        _mapper = new();
    }

    /// <summary>
    /// Get user subscription
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET: api/subscriptions/69128754-e11b-4b59-bef4-d2a2588a374f
    /// </remarks>
    /// <param name="id">The Id of the subscription</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The user subscription</returns>
    [HttpGet("{id:guid}", Name = "GetSubscriptionAsync")]
    [ProducesResponseType(typeof(SubscriptionResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status404NotFound)]
    public async Task<IResult> GetSubscriptionAsync(Guid id, CancellationToken cancellationToken)
    {
        var subscription = await _subscriptionService.GetForUserAsync(UserId, id, cancellationToken);
        return Results.Ok(_mapper.Map(subscription));
    }

    /// <summary>
    /// Get all subscriptions for user
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET: api/subscriptions
    /// </remarks>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The list of all subscriptions for user</returns>
    [HttpGet]
    [ProducesResponseType(typeof(ICollection<SubscriptionResponse>), StatusCodes.Status200OK)]
    public async Task<IResult> GetSubscriptionsAsync(CancellationToken cancellationToken)
    {
        var subscriptions = await _subscriptionService.GetAllForUserAsync(UserId, cancellationToken);
        return Results.Ok(_mapper.Map(subscriptions));
    }

    /// <summary>
    /// Create user subscription
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST: api/subscriptions
    ///     {
    ///         "service": "Obsidian",
    ///         "price": 10,
    ///         "currencyId": "657df0a1-15e1-4048-a03a-5311aa3d03df",
    ///         "isActive": true
    ///     }
    /// </remarks>
    /// <param name="request">The create subscription request</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The newly created user subscription</returns>
    [HttpPost]
    [ProducesResponseType(typeof(SubscriptionResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status404NotFound)]
    public async Task<IResult> CreateSubscriptionAsync([FromBody] CreateSubscriptionRequest request, CancellationToken cancellationToken)
    {
        var createSubscriptionDto = _mapper.Map(request);
        var subscription = await _subscriptionService.CreateAsync(UserId, createSubscriptionDto, cancellationToken);
        var response = _mapper.Map(subscription);
        return Results.CreatedAtRoute("GetSubscriptionAsync", new { response.Id }, response);
    }

    /// <summary>
    /// Update user subscription
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     PUT: api/subscriptions/888db9d1-30e3-4190-a654-7d17a5bbb545
    ///     {
    ///     {
    ///         "service": "Obsidian",
    ///         "price": "10",
    ///         "currencyId": "657df0a1-15e1-4048-a03a-5311aa3d03df",
    ///         "isActive": "false"
    ///     }
    /// </remarks>
    /// <param name="id">The Id of the subscription</param>
    /// <param name="request">The update subscription request</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns></returns>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status404NotFound)]
    public async Task<IResult> UpdateSubscriptionAsync(Guid id, [FromBody] UpdateSubscriptionRequest request, CancellationToken cancellationToken)
    {
        var updateSubscriptionDto = _mapper.Map(request);
        await _subscriptionService.UpdateAsync(UserId, id, updateSubscriptionDto, cancellationToken);
        return Results.NoContent();
    }

    /// <summary>
    /// Delete user subscription
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     DELETE: api/subscriptions/105c8926-d5dc-43e7-9792-8702e43cd128
    /// </remarks>
    /// <param name="id">The Id of the subscription</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns></returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status404NotFound)]
    public async Task<IResult> DeleteSubscriptionAsync(Guid id, CancellationToken cancellationToken)
    {
        await _subscriptionService.DeleteAsync(UserId, id, cancellationToken);
        return Results.NoContent();
    }
}
