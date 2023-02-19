using AutoMapper;

using Flow.Api.Models.Subscription;
using Flow.Business.Models.Subscription;

namespace Flow.Api.Mappings;

internal sealed class SubscriptionProfile : Profile
{
    public SubscriptionProfile()
    {
        CreateMap<CreateSubscriptionRequest, CreateSubscriptionDto>();
        CreateMap<SubscriptionDto, SubscriptionResponse>();
    }
}
