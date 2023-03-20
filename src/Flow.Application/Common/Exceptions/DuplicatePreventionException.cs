namespace Flow.Application.Common.Exceptions;

[Serializable]
public class DuplicatePreventionException : Exception
{
    public DuplicatePreventionException() : base("The same entity already exists.") { }

    public DuplicatePreventionException(string message) : base(message) { }

    public DuplicatePreventionException(string message, Exception inner) : base(message, inner) { }

    protected DuplicatePreventionException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}
