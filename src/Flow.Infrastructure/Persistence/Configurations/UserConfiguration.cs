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
            .HasConversion(x => x.Value, x => Email.Create(x).Value)
            .HasMaxLength(Email.MaxLength);

        builder.Property(x => x.PasswordHash)
            .HasConversion(x => x.Value, x => PasswordHash.Create(x).Value)
            .HasMaxLength(PasswordHash.MaxLength);
    }
}