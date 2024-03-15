using Ardalis.GuardClauses;

namespace Flow.Domain.Abstractions;

public abstract class Entity
{
    protected Entity(Guid id)
    {
        Id = Guard.Against.Default(id);
    }

    protected Entity()
    {
    }

    public Guid Id { get; init; }

    public override bool Equals(object? obj)
    {
        if (obj is not Entity other)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        if (Id.Equals(Guid.Empty) || other.Id.Equals(Guid.Empty))
            return false;

        return Id.Equals(other.Id);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}