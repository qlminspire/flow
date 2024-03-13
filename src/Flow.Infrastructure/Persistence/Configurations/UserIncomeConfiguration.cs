using Flow.Domain.Income;

namespace Flow.Infrastructure.Persistence.Configurations;

internal sealed class UserIncomeConfiguration : IEntityTypeConfiguration<UserIncome>
{
    public void Configure(EntityTypeBuilder<UserIncome> builder)
    {
        builder.Property(x => x.Amount)
            .HasConversion(x => x.Value, x => Money.Create(x).Value);

        builder.HasOne(x => x.Account)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);
    }
}