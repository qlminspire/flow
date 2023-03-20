namespace Flow.Domain.Common;

public interface IHasCreateDate
{
    DateTimeOffset? CreateDate { get; set; }
}
