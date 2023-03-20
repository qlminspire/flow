namespace Flow.Domain.Common;

public interface IHasUpdateDate
{
    DateTimeOffset? UpdateDate { get; set; }
}
