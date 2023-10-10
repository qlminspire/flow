namespace Flow.Domain.Common;

public interface IHasDate
{
    DateTimeOffset CreatedAt { get; set; }

    DateTimeOffset? UpdatedAt { get; set; }
}
