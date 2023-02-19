using AutoMapper;

using Flow.Business.Models.Subscription;
using Flow.Entities;

namespace Flow.Business.Mappings;

internal sealed class SubscriptionProfile: Profile
{
	public SubscriptionProfile()
	{
		CreateMap<Subscription, SubscriptionDto>()
			.ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency.Code));
		CreateMap<CreateSubscriptionDto, Subscription>();
		CreateMap<UpdateSubscriptionDto, Subscription>();
	}
}
