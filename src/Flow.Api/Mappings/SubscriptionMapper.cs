using Riok.Mapperly.Abstractions;

using Flow.Api.Contracts.Requests.Subscription;
using Flow.Api.Contracts.Responses.Subscription;

using Flow.Application.Models.Subscription;

namespace Flow.Api.Mappings;

[Mapper]
internal partial class SubscriptionMapper
{
    public partial SubscriptionResponse Map(SubscriptionDto subscriptionDto);
    //.ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency.Code));

    public partial ICollection<SubscriptionResponse> Map(ICollection<SubscriptionDto> subscriptionsDto);

    public partial CreateSubscriptionDto Map(CreateSubscriptionRequest createSubscriptionRequest);

    public partial UpdateSubscriptionDto Map(UpdateSubscriptionRequest updateSubscriptionRequest);
}
