using Flow.Application.Models.AccountOperation;
using Riok.Mapperly.Abstractions;

namespace Flow.Application.Mappings;

[Mapper]
public partial class AccountOperationMapper
{
    public partial AccountOperationDto Map(AccountOperation accountOperation);

    public partial AccountOperation Map(CreateAccountOperationDto createAccountOperationDto);
}
