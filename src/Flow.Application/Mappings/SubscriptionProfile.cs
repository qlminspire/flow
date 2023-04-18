using AutoMapper;
using Flow.Application.Models.Subscription;
using Flow.Domain.Entities;

namespace Flow.Application.Mappings;

internal sealed class SubscriptionProfile : Profile
{
    public SubscriptionProfile()
    {
        CreateMap<Subscription, SubscriptionDto>();
        CreateMap<CreateSubscriptionDto, Subscription>();
        CreateMap<UpdateSubscriptionDto, Subscription>();
    }
}
