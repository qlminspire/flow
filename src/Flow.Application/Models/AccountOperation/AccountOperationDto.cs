using Flow.Domain.Enums;

namespace Flow.Application.Models.AccountOperation;

public class AccountOperationDto
{
    public AccountOperationType OperationType { get; set; }

    public Guid AccountId { get; set; }

    public decimal Price { get; set; }

    public DateTimeOffset? CreateDate { get; set; }

    public DateTimeOffset? UpdateDate { get; set; }
}
