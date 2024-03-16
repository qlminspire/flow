using Flow.Domain.Accounts;
using Flow.Domain.Banks;

namespace Flow.Infrastructure.Persistence.Configurations;

internal sealed class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
{
    public void Configure(EntityTypeBuilder<BankAccount> builder)
    {
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new AccountId(x));

        builder.Property(x => x.Iban)
            .HasConversion(x => x.Value, x => Iban.Create(x).Value)
            .HasMaxLength(Iban.MaxLength);

        builder.Property(x => x.BankId)
            .HasConversion(x => x.Value, x => new BankId(x));

        builder.HasOne(x => x.Bank).WithMany().OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(x => x.Deposits).WithOne(x => x.RefundAccount).OnDelete(DeleteBehavior.Restrict);
    }
}