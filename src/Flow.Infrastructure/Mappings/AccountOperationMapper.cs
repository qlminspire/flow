using Flow.Application.Models.AccountOperation;
using Flow.Domain.AccountOperations;
using Riok.Mapperly.Abstractions;

namespace Flow.Infrastructure.Mappings;

[Mapper]
internal partial class AccountOperationMapper
{
    public partial AccountOperationDto Map(AccountOperation accountOperation);

    private decimal MoneyToDecimal(Money money) => money.Value;

    private Guid IdToGuid(AccountOperationId id) => id.Value;
}