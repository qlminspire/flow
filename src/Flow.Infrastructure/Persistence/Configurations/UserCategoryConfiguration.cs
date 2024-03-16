using Flow.Domain.UserCategories;
using Flow.Domain.Users;

namespace Flow.Infrastructure.Persistence.Configurations;

internal sealed class UserCategoryConfiguration : IEntityTypeConfiguration<UserCategory>
{
    public void Configure(EntityTypeBuilder<UserCategory> builder)
    {
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new UserCategoryId(x));

        builder.HasIndex(x => new { x.UserId, x.Name })
            .IsUnique();

        builder.Property(x => x.Name)
            .HasConversion(x => x.Value, x => UserCategoryName.Create(x).Value)
            .HasMaxLength(UserCategoryName.MaxLength);

        builder.Property(x => x.UserId)
            .HasConversion(x => x.Value, x => new UserId(x));

        builder.HasOne(x => x.User)
            .WithMany()
            .OnDelete(DeleteBehavior.Cascade);
    }
}