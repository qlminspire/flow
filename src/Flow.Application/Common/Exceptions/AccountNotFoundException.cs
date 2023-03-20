namespace Flow.Application.Common.Exceptions;

[Serializable]
public class AccountNotFoundException : NotFoundException
{
    public AccountNotFoundException() { }

    public AccountNotFoundException(Guid userId, Guid accountId) : base($"Can't find account with ID: {accountId} for user: {userId}") { }

    public AccountNotFoundException(string message) : base(message) { }

    public AccountNotFoundException(string message, Exception inner) : base(message, inner) { }

    protected AccountNotFoundException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}