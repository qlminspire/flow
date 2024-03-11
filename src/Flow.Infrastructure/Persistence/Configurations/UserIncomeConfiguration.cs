using Flow.Domain.Income;

namespace Flow.Infrastructure.Persistence.Configurations;

internal sealed class UserIncomeConfiguration : IEntityTypeConfiguration<UserIncome>
{
    public void Configure(EntityTypeBuilder<UserIncome> builder)
    {
        builder.HasOne(x => x.Account).WithOne().OnDelete(DeleteBehavior.Cascade);
    }
}