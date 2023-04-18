using AutoMapper;

using Flow.Api.Models.Subscription;

using Flow.Application.Models.Subscription;

namespace Flow.Api.Mappings;

internal sealed class SubscriptionProfile : Profile
{
    public SubscriptionProfile()
    {
        CreateMap<SubscriptionDto, SubscriptionResponse>()
            .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency.Code));
        CreateMap<CreateSubscriptionRequest, CreateSubscriptionDto>();
    }
}
