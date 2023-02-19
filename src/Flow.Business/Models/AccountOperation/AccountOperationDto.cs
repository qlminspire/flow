using Flow.Entities.Core.Enums;

namespace Flow.Api.Models.AccountOperation;

public class AccountOperationDto
{
    public AccountOperationType OperationType { get; set; }

    public Guid AccountId { get; set; }

    public decimal Price { get; set; }

    public DateTimeOffset? CreateDate { get; set; }

    public DateTimeOffset? UpdateDate { get; set; }
}
