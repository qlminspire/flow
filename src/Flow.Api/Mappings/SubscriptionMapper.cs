using Flow.Application.Models.Subscription;
using Flow.Contracts.Requests.Subscription;
using Flow.Contracts.Responses.Subscription;
using Riok.Mapperly.Abstractions;

namespace Flow.Api.Mappings;

[Mapper]
internal partial class SubscriptionMapper
{
    public partial SubscriptionResponse Map(SubscriptionDto subscriptionDto);

    public partial ICollection<SubscriptionResponse> Map(ICollection<SubscriptionDto> subscriptionsDto);

    public partial CreateSubscriptionDto Map(CreateSubscriptionRequest createSubscriptionRequest);
}