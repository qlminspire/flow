namespace Flow.Application.Common;

public interface IDateTimeProvider
{
    public DateTimeOffset Now { get; }
}