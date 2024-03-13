using Flow.Domain.Debts;

namespace Flow.Infrastructure.Persistence.Configurations;

internal sealed class DebtConfiguration : IEntityTypeConfiguration<Debt>
{
    public void Configure(EntityTypeBuilder<Debt> builder)
    {
        builder.Property(x => x.Name)
            .HasConversion(x => x.Value, x => DebtName.Create(x).Value)
            .HasMaxLength(DebtName.MaxLength);

        builder.Property(x => x.Amount)
            .HasConversion(x => x.Value, x => Money.Create(x).Value);
    }
}