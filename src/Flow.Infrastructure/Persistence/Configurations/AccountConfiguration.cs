using Flow.Domain.Accounts;

namespace Flow.Infrastructure.Persistence.Configurations;

internal sealed class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.UseTptMappingStrategy();

        builder.HasOne(x => x.Currency).WithMany().OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.User).WithMany().OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.Category).WithMany().OnDelete(DeleteBehavior.SetNull);
    }
}