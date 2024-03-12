using Flow.Domain.Banks;

namespace Flow.Infrastructure.Persistence.Configurations;

internal sealed class BankConfiguration : IEntityTypeConfiguration<Bank>
{
    public void Configure(EntityTypeBuilder<Bank> builder)
    {
        builder.Property(x => x.Id);

        builder.HasIndex(x => x.Name)
            .IsUnique();

        builder.Property(x => x.Name)
            .HasMaxLength(BankName.MaxLength)
            .HasConversion(x => x.Value,
                x => BankName.Create(x).Value);

        builder.Property(x => x.IsDeactivated);
    }
}