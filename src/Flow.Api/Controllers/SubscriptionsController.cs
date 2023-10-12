using Microsoft.AspNetCore.Mvc;

using Flow.Api.Contracts.Requests.Subscription;

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

    [HttpGet("{id:guid}", Name = "GetSubscriptionAsync")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
    public async Task<IResult> GetSubscriptionAsync(Guid id, CancellationToken cancellationToken)
    {
        var subscription = await _subscriptionService.GetAsync(UserId, id, cancellationToken);
        return Results.Ok(_mapper.Map(subscription));
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IResult> GetSubscriptionsAsync(CancellationToken cancellationToken)
    {
        var subscriptions = await _subscriptionService.GetAllAsync(UserId, cancellationToken);
        var response = _mapper.Map(subscriptions);
        return Results.Ok(response);
    }

    [HttpPost]
    public async Task<IResult> CreateSubscriptionAsync([FromBody] CreateSubscriptionRequest request, CancellationToken cancellationToken)
    {
        var createSubscriptionDto = _mapper.Map(request);
        var subscription = await _subscriptionService.CreateAsync(UserId, createSubscriptionDto, cancellationToken);
        var response = _mapper.Map(subscription);
        return Results.CreatedAtRoute("GetSubscriptionAsync", new { response.Id }, response);
    }

    [HttpPut("{id:guid}")]
    public async Task<IResult> UpdateSubscriptionAsync(Guid id, [FromBody] UpdateSubscriptionRequest request, CancellationToken cancellationToken)
    {
        var updateSubscriptionDto = _mapper.Map(request);
        await _subscriptionService.UpdateAsync(UserId, id, updateSubscriptionDto, cancellationToken);
        return Results.NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IResult> DeleteSubscriptionAsync(Guid id, CancellationToken cancellationToken)
    {
        await _subscriptionService.DeleteAsync(UserId, id, cancellationToken);
        return Results.NoContent();
    }
}
