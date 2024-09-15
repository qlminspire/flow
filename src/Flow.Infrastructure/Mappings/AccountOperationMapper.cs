using Flow.Application.Models.AccountOperation;
using Flow.Domain.AccountOperations;
using Riok.Mapperly.Abstractions;

namespace Flow.Infrastructure.Mappings;

[Mapper]
internal sealed partial class AccountOperationMapper
{
    public partial AccountOperationDto Map(AccountOperation accountOperation);

    private static decimal MoneyToDecimal(Money money) => money.Value;

    private static Guid IdToGuid(AccountOperationId id) => id.Value;
}