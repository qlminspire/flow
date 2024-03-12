using Ardalis.GuardClauses;

namespace Flow.Domain.Shared;

public sealed record DateRange: IValueObject
{
    private DateRange(DateOnly start, DateOnly end)
    {
        Start = start;
        End = end;
    }

    public DateOnly Start { get; }

    public DateOnly End { get; }

    public int Days => End.DayNumber - Start.DayNumber;

    public static DateRange Create(DateOnly start, DateOnly end)
    {
        Guard.Against.Default(start);
        Guard.Against.Default(end);
        Guard.Against.Expression(date => date > start, end, "End date precedes start date");

        return new DateRange(start, end);
    }
}