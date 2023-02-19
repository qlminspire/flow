namespace Flow.Entities.Core.Exceptions;

[Serializable]
public class SubscriptionNotFoundException : NotFoundException
{
    public SubscriptionNotFoundException() { }

    public SubscriptionNotFoundException(Guid userId, Guid subscriptionId) : base($"Can't find subscription with ID: {subscriptionId} for user: {userId}") { }

    public SubscriptionNotFoundException(string message) : base(message) { }

    public SubscriptionNotFoundException(string message, Exception inner) : base(message, inner) { }

    protected SubscriptionNotFoundException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}