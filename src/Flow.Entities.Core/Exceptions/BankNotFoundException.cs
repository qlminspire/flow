namespace Flow.Entities.Core.Exceptions;

[Serializable]
public class BankNotFoundException : NotFoundException
{
    public BankNotFoundException() { }

    public BankNotFoundException(Guid id) : base($"Can't find bank with ID: {id}") { }

    public BankNotFoundException(string message) : base(message) { }

    public BankNotFoundException(string message, Exception inner) : base(message, inner) { }

    protected BankNotFoundException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}