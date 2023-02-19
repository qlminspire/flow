using Flow.DataAccess.Constants;
using Flow.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flow.DataAccess.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasAlternateKey(x => x.Email);
        builder.Property(x => x.Email).HasMaxLength(DatabaseConstants.Length256);
    }
}
