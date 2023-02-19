namespace Flow.Entities.Core.Exceptions;

[Serializable]
public abstract class NotFoundException : ApplicationException
{
	public NotFoundException() { }

	public NotFoundException(string message) : base(message) { }

	public NotFoundException(string message, Exception inner) : base(message, inner) { }

	protected NotFoundException(
	  System.Runtime.Serialization.SerializationInfo info,
	  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}