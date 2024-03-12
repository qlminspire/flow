using Flow.Application.Models.Subscription;
using Flow.Domain.Shared;
using Flow.Domain.Subscriptions;
using Riok.Mapperly.Abstractions;

namespace Flow.Infrastructure.Mappings;

[Mapper]
internal partial class SubscriptionMapper
{
    public partial SubscriptionDto Map(Subscription subscription);

    public partial List<SubscriptionDto> Map(List<Subscription> subscriptions);

    private int PaymentFrequencyMonthsToInt(PaymentFrequencyMonths paymentFrequencyMonths) =>
        paymentFrequencyMonths.Value;

    private decimal MoneyToDecimal(Money money) => money.Value;

    private string SubscriptionNameToString(SubscriptionName subscriptionName) => subscriptionName.Value;
}