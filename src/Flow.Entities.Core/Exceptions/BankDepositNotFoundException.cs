namespace Flow.Entities.Core.Exceptions;

[Serializable]
public class BankDepositNotFoundException : NotFoundException
{
	public BankDepositNotFoundException() { }

	public BankDepositNotFoundException(Guid userId, Guid accountId): base($"Can't find bank deposit with ID: {accountId} for user: {userId}") { }

	public BankDepositNotFoundException(string message) : base(message) { }

	public BankDepositNotFoundException(string message, Exception inner) : base(message, inner) { }

	protected BankDepositNotFoundException(
	  System.Runtime.Serialization.SerializationInfo info,
	  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}