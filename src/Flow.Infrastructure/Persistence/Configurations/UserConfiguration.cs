using Flow.Domain.Users;

namespace Flow.Infrastructure.Persistence.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.Id);

        builder.HasIndex(x => x.Email)
            .IsUnique();

        builder.Property(x => x.Email)
            .HasMaxLength(DatabaseConstants.Length256)
            .HasConversion(x => x.Value, x => new Email(x));

        builder.Property(x => x.PasswordHash)
            .HasMaxLength(DatabaseConstants.Length512);
    }
}