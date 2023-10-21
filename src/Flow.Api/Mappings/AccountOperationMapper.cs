using Riok.Mapperly.Abstractions;
using Flow.Application.Models.AccountOperation;
using Flow.Contracts.Requests.AccountOperation;
using Flow.Contracts.Responses.AccountOperation;

namespace Flow.Api.Mappings;

[Mapper]
internal partial class AccountOperationMapper
{
    public partial CreateAccountOperationDto Map(CreateAccountOperationRequest createAccountOperationRequest);

    public partial AccountOperationResponse Map(AccountOperationDto accountOperationDto);
}
