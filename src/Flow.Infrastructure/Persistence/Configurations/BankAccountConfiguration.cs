using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flow.Infrastructure.Persistence.Configurations;

internal sealed class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
{
    public void Configure(EntityTypeBuilder<BankAccount> builder)
    {
        builder.Property(x => x.Iban).HasMaxLength(DatabaseConstants.Length64);
        builder.HasOne(x => x.Bank).WithMany().OnDelete(DeleteBehavior.Restrict);
    }
}
