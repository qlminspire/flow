using Flow.Application.Models.Subscription;
using Riok.Mapperly.Abstractions;

namespace Flow.Application.Mappings;

[Mapper]
public partial class SubscriptionMapper
{
    public partial SubscriptionDto Map(Subscription subscription);

    public partial List<SubscriptionDto> Map(List<Subscription> subscriptions);

    public partial Subscription Map(CreateSubscriptionDto createSubscriptionDto);

    public partial void Map(Subscription subscription, UpdateSubscriptionDto updateSubscriptionDto);
}
