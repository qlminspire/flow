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

    public DateTime CreatedAt { get; private set; }

    public DateTime? UpdatedAt { get; private set; }

    public bool IsDeactivated { get; private set; }

    public DateTime? DeactivatedAt { get; private set; }

    public static Result<Bank> Create(BankName bankName, DateTime createdAt)
    {
        var bank = new Bank(Guid.NewGuid(), bankName, createdAt);

        return bank;
    }

    public Result Activate(DateTime activatedAt)
    {
        IsDeactivated = false;
        UpdatedAt = activatedAt;

        return Result.Success();
    }

    public Result Deactivate(DateTime deactivatedAt)
    {
        IsDeactivated = true;
        UpdatedAt = deactivatedAt;
        DeactivatedAt = deactivatedAt;

        return Result.Success();
    }
}