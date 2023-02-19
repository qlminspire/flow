using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using Flow.Api.Models.Subscription;
using Flow.Business.Services;
using Flow.Business.Models.Subscription;

namespace Flow.Api.Controllers.Finance;

public class SubscriptionsController : BaseController
{
    private readonly ISubscriptionService _subscriptionService;
    private readonly IMapper _mapper;

    public SubscriptionsController(ISubscriptionService subscriptionService, IMapper mapper)
    {
        _subscriptionService = subscriptionService;
        _mapper = mapper;
    }

    [HttpGet("{id:guid}", Name = "GetSubscriptionAsync")]
    public async Task<SubscriptionResponse> GetSubscriptionAsync(Guid id, CancellationToken cancellationToken)
    {
        var subscription = await _subscriptionService.GetAsync(UserId, id, cancellationToken);
        return _mapper.Map<SubscriptionResponse>(subscription);
    }

    [HttpGet]
    public async Task<ICollection<SubscriptionResponse>> GetSubscriptionsAsync(CancellationToken cancellationToken)
    {
        var subscriptions = await _subscriptionService.GetAllAsync(UserId, cancellationToken);
        return _mapper.Map<ICollection<SubscriptionResponse>>(subscriptions);
    }

    [HttpPost]
    public async Task<IResult> CreateSubscriptionAsync([FromBody] CreateSubscriptionRequest request, CancellationToken cancellationToken)
    {
        var createSubscriptionDto = _mapper.Map<CreateSubscriptionDto>(request);
        var subscription = await _subscriptionService.CreateAsync(UserId, createSubscriptionDto, cancellationToken);
        var response = _mapper.Map<SubscriptionResponse>(subscription);
        return Results.CreatedAtRoute("GetSubscriptionAsync", new { response.Id }, response);
    }

    [HttpPut("{id:guid}")]
    public async Task<IResult> UpdateSubscriptionAsync(Guid id, [FromBody] UpdateSubscriptionRequest request, CancellationToken cancellationToken)
    {
        var updateSubscriptionDto = _mapper.Map<UpdateSubscriptionDto>(request);
        await _subscriptionService.UpdateAsync(UserId, id, updateSubscriptionDto, cancellationToken);
        return Results.Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IResult> DeleteSubscriptionAsync(Guid id, CancellationToken cancellationToken)
    {
        await _subscriptionService.DeleteAsync(UserId, id, cancellationToken);
        return Results.Ok();
    }
}
