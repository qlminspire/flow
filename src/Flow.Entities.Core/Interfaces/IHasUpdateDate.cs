namespace Flow.Entities.Core.Interfaces;

public interface IHasUpdateDate
{
    DateTimeOffset? UpdateDate { get; set; }
}
