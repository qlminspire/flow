using Flow.Application.Models.AccountOperation;
using Flow.Domain.AccountOperations;
using Riok.Mapperly.Abstractions;

namespace Flow.Infrastructure.Mappings;

[Mapper]
internal partial class AccountOperationMapper
{
    public partial AccountOperationDto Map(AccountOperation accountOperation);

    public partial AccountOperation Map(CreateAccountOperationDto createAccountOperationDto);
}