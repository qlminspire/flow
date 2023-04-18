namespace Flow.Application.Common.Exceptions;

[Serializable]
public class PlannedExpenseNotFoundException : NotFoundException
{
    public PlannedExpenseNotFoundException() { }

    public PlannedExpenseNotFoundException(Guid userId, Guid plannedExpenseId) : base($"Can't find planned expense with ID: {plannedExpenseId} for user: {userId}") { }

    public PlannedExpenseNotFoundException(string message) : base(message) { }

    public PlannedExpenseNotFoundException(string message, Exception inner) : base(message, inner) { }

    protected PlannedExpenseNotFoundException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}