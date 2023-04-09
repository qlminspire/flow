using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Flow.Domain.Entities;
using Flow.Infrastructure.Persistence.Constants;

namespace Flow.Infrastructure.Persistence.Configurations;

internal sealed class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.Property(x => x.Service).HasMaxLength(DatabaseConstants.Length64);
        builder.Property(x => x.IsActive).HasDefaultValue(true);
    }
}
