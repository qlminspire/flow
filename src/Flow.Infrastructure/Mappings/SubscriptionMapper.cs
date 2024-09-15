using Flow.Application.Models.Subscription;
using Flow.Domain.Currencies;
using Flow.Domain.Subscriptions;
using Riok.Mapperly.Abstractions;

namespace Flow.Infrastructure.Mappings;

[Mapper]
internal sealed partial class SubscriptionMapper
{
    public partial SubscriptionDto Map(Subscription subscription);

    public partial List<SubscriptionDto> Map(List<Subscription> subscriptions);

    private static int PaymentFrequencyMonthsToInt(PaymentFrequencyMonths paymentFrequencyMonths) =>
        paymentFrequencyMonths.Value;

    private static decimal MoneyToDecimal(Money money) => money.Value;

    private static string SubscriptionNameToString(SubscriptionName subscriptionName) => subscriptionName.Value;

    private static string CurrencyToString(Currency currency) => currency.Code.Value;

    private static Guid IdToGuid(SubscriptionId id) => id.Value;
}