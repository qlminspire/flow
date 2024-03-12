using Ardalis.GuardClauses;

namespace Flow.Domain.Banks;

public sealed class Bank : AggregateRoot, IAuditable, IDeactivatable
{
    private Bank(
        Guid id,
        BankName name,
        DateTime createdAt)
        : base(id)
    {
        Guard.Against.NullOrWhiteSpace(name.Value);

        Name = name;
        CreatedAt = Guard.Against.Default(createdAt);
    }

    private Bank()
    {
    }

    public BankName Name { get; private set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsDeactivated { get; private set; }

    public DateTime? DeactivatedAt { get; private set; }

    public static Result<Bank> Create(BankName bankName, DateTime date)
    {
        var bank = new Bank(Guid.NewGuid(), bankName, date);

        return bank;
    }

    public Result Activate(DateTime date)
    {
        IsDeactivated = false;
        UpdatedAt = date;

        return Result.Success();
    }

    public Result Deactivate(DateTime date)
    {
        IsDeactivated = true;
        UpdatedAt = date;
        DeactivatedAt = date;

        return Result.Success();
    }
}