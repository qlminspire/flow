namespace Flow.Entities.Core.Exceptions;

[Serializable]
public class CurrencyNotFoundException : NotFoundException
{
	public CurrencyNotFoundException() { }

	public CurrencyNotFoundException(Guid id) : base($"Can't find currency with ID: {id}") { }

	public CurrencyNotFoundException(string message) : base(message) { }

	public CurrencyNotFoundException(string message, Exception inner) : base(message, inner) { }

	protected CurrencyNotFoundException(
	  System.Runtime.Serialization.SerializationInfo info,
	  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}