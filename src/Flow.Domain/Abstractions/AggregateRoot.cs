namespace Flow.Domain.Abstractions;

public abstract class AggregateRoot<TKey> : Entity<TKey>
    where TKey : EntityId
{
    private readonly List<IDomainEvent> _domainEvents = [];

    protected AggregateRoot(TKey id)
        : base(id)
    {
    }

    protected AggregateRoot()
    {
    }

    public List<IDomainEvent> GetDomainEvents()
    {
        return _domainEvents.ToList();
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}