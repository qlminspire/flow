using Flow.Domain.Entities;
using Flow.Infrastructure.Persistance.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flow.Infrastructure.Persistance.Configurations;

internal sealed class UserCategoryConfiguration : IEntityTypeConfiguration<UserCategory>
{
    public void Configure(EntityTypeBuilder<UserCategory> builder)
    {
        builder.HasIndex(x => new { x.UserId, x.Name }).IsUnique();
        builder.Property(x => x.Name).HasMaxLength(DatabaseConstants.Length64);
        builder.Property(x => x.Description).HasMaxLength(DatabaseConstants.Length128);
        builder.HasOne(x => x.User).WithMany().OnDelete(DeleteBehavior.Cascade);
    }
}
