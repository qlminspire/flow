using Flow.Domain.Accounts;

namespace Flow.Infrastructure.Persistence.Configurations;

internal sealed class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.UseTptMappingStrategy();

        builder.Property(x => x.Name)
            .HasConversion(x => x.Value, x => AccountName.Create(x).Value)
            .HasMaxLength(AccountName.MaxLength);

        builder.Property(x => x.Balance)
            .HasConversion(x => x.Value, x => Money.Create(x).Value);

        builder.HasOne(x => x.Currency).WithMany().OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.User).WithMany().OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.Category).WithMany().OnDelete(DeleteBehavior.SetNull);
    }
}