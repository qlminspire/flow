using Flow.Domain.Accounts;

namespace Flow.Infrastructure.Persistence.Configurations;

internal sealed class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
{
    public void Configure(EntityTypeBuilder<BankAccount> builder)
    {
        builder.Property(x => x.Iban)
            .HasConversion(x => x.Value, x => Iban.Create(x).Value)
            .HasMaxLength(Iban.MaxLength);

        builder.HasOne(x => x.Bank).WithMany().OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(x => x.Deposits).WithOne(x => x.RefundAccount).OnDelete(DeleteBehavior.Restrict);
    }
}