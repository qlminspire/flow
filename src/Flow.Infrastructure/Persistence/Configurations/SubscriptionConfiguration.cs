using Flow.Domain.Subscriptions;

namespace Flow.Infrastructure.Persistence.Configurations;

internal sealed class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(DatabaseConstants.Length64);
    }
}