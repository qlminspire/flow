using Riok.Mapperly.Abstractions;

using Flow.Application.Models.AccountOperation;

namespace Flow.Infrastructure.Mappings;

[Mapper]
internal partial class AccountOperationMapper
{
    public partial AccountOperationDto Map(AccountOperation accountOperation);

    public partial AccountOperation Map(CreateAccountOperationDto createAccountOperationDto);
}
