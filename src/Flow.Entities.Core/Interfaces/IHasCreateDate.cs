namespace Flow.Entities.Core.Interfaces;

public interface IHasCreateDate
{
    DateTimeOffset? CreateDate { get; set; }
}
