using Flow.Domain.Subscriptions;

namespace Flow.Infrastructure.Persistence.Configurations;

internal sealed class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.Property(x => x.Name)
            .HasConversion(x => x.Value, x => SubscriptionName.Create(x).Value)
            .HasMaxLength(SubscriptionName.MaxLength);

        builder.Property(x => x.PaymentFrequencyMonths)
            .HasConversion(x => x.Value, x => PaymentFrequencyMonths.Create(x).Value);

        builder.Property(x => x.Price)
            .HasConversion(x => x.Value, x => Money.Create(x).Value);
    }
}