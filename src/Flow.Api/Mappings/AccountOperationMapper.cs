using Flow.Application.Models.AccountOperation;
using Flow.Contracts.Requests.AccountOperation;
using Flow.Contracts.Responses.AccountOperation;
using Riok.Mapperly.Abstractions;

namespace Flow.Api.Mappings;

[Mapper]
internal sealed partial class AccountOperationMapper
{
    public partial CreateAccountOperationDto Map(CreateAccountOperationRequest createAccountOperationRequest);

    public partial AccountOperationResponse Map(AccountOperationDto accountOperationDto);
}