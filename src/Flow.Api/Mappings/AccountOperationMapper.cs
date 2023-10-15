using Riok.Mapperly.Abstractions;

using Flow.Api.Contracts.Requests.AccountOperation;
using Flow.Api.Contracts.Responses.AccountOperation;

using Flow.Application.Models.AccountOperation;

namespace Flow.Api.Mappings;

[Mapper]
internal partial class AccountOperationMapper
{
    public partial CreateAccountOperationDto Map(CreateAccountOperationRequest createAccountOperationRequest);

    public partial AccountOperationResponse Map(AccountOperationDto accountOperationDto);
}
