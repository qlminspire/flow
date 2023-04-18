namespace Flow.Application.Common;

public interface IDateTimeProvider
{
    DateTimeOffset Now { get; }

    DateTimeOffset UtcNow { get; }
}