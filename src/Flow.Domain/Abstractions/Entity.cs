namespace Flow.Domain.Abstractions;

public abstract class Entity<TKey>
    where TKey : EntityId
{
    protected Entity(TKey id)
    {
        Id = id;
    }

    protected Entity()
    {
    }

    public TKey Id { get; init; }

    public override bool Equals(object? obj)
    {
        if (obj is not Entity<TKey> other)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        if (Id.Equals(default) || other.Id.Equals(default))
            return false;

        return Id.Equals(other.Id);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}