namespace Flow.Domain.Shared;

public sealed record DateRange : IValueObject
{
    private static readonly Error StartDateAfterEndDateError = new(
        "DateRange.StartDateAfterEndDate", "The start date must be before end date");

    private DateRange(DateOnly start, DateOnly end)
    {
        Start = start;
        End = end;
    }

    public DateOnly Start { get; }

    public DateOnly End { get; }

    public int Days => End.DayNumber - Start.DayNumber;

    public static Result<DateRange> Create(DateOnly start, DateOnly end)
    {
        if (start == default)
            return Result.Failure<DateRange>(Error.DefaultValueError);

        if (end == default)
            return Result.Failure<DateRange>(Error.DefaultValueError);

        if (start >= end)
            return Result.Failure<DateRange>(StartDateAfterEndDateError);

        return new DateRange(start, end);
    }
}