using Riok.Mapperly.Abstractions;

using Flow.Application.Models.Subscription;

namespace Flow.Infrastructure.Mappings;

[Mapper]
internal partial class SubscriptionMapper
{
    public partial SubscriptionDto Map(Subscription subscription);

    public partial List<SubscriptionDto> Map(List<Subscription> subscriptions);

    public partial Subscription Map(CreateSubscriptionDto createSubscriptionDto);

    public partial void Map(UpdateSubscriptionDto updateSubscriptionDto, Subscription subscription);
}
