using Flow.Domain.Accounts;
using Flow.Domain.Currencies;
using Flow.Domain.UserCategories;
using Flow.Domain.Users;

namespace Flow.Infrastructure.Persistence.Configurations;

internal sealed class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.UseTptMappingStrategy();

        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new AccountId(x));

        builder.Property(x => x.Name)
            .HasConversion(x => x.Value, x => AccountName.Create(x).Value)
            .HasMaxLength(AccountName.MaxLength);

        builder.Property(x => x.Balance)
            .HasConversion(x => x.Value, x => Money.Create(x).Value);

        builder.Property(x => x.CurrencyId)
            .HasConversion(x => x.Value, x => new CurrencyId(x));

        builder.Property(x => x.UserId)
            .HasConversion(x => x.Value, x => new UserId(x));

        builder.Property(x => x.CategoryId)
            .HasConversion(x => x.Value, x => new UserCategoryId(x));

        builder.HasOne(x => x.Currency).WithMany().OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.User).WithMany().OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.Category).WithMany().OnDelete(DeleteBehavior.SetNull);
    }
}