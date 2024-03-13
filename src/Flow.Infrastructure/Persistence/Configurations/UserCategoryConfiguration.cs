using Flow.Domain.UserCategories;

namespace Flow.Infrastructure.Persistence.Configurations;

internal sealed class UserCategoryConfiguration : IEntityTypeConfiguration<UserCategory>
{
    public void Configure(EntityTypeBuilder<UserCategory> builder)
    {
        builder.HasIndex(x => new { x.UserId, x.Name })
            .IsUnique();

        builder.Property(x => x.Name)
            .HasConversion(x => x.Value, x => UserCategoryName.Create(x).Value)
            .HasMaxLength(UserCategoryName.MaxLength);

        builder.HasOne(x => x.User)
            .WithMany()
            .OnDelete(DeleteBehavior.Cascade);
    }
}