using Flow.Domain.Currencies;
using Flow.Domain.Subscriptions;
using Flow.Domain.Users;

namespace Flow.Infrastructure.Persistence.Configurations;

internal sealed class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new SubscriptionId(x));

        builder.Property(x => x.Name)
            .HasConversion(x => x.Value, x => SubscriptionName.Create(x).Value)
            .HasMaxLength(SubscriptionName.MaxLength);

        builder.Property(x => x.PaymentFrequencyMonths)
            .HasConversion(x => x.Value, x => PaymentFrequencyMonths.Create(x).Value);

        builder.Property(x => x.Price)
            .HasConversion(x => x.Value, x => Money.Create(x).Value);

        builder.Property(x => x.UserId)
            .HasConversion(x => x.Value, x => new UserId(x));

        builder.Property(x => x.CurrencyId)
            .HasConversion(x => x.Value, x => new CurrencyId(x));
    }
}