using Riok.Mapperly.Abstractions;
using Flow.Application.Models.CashAccount;
using Flow.Contracts.Requests.CashAccount;
using Flow.Contracts.Responses.CashAccount;

namespace Flow.Api.Mappings;

[Mapper]
internal partial class CashAccountMapper
{
    public partial CashAccountResponse Map(CashAccountDto cashAccountDto);

    public partial ICollection<CashAccountResponse> Map(ICollection<CashAccountDto> cashAccountsDto);

    public partial CreateCashAccountDto Map(CreateCashAccountRequest createCashAccountRequest);
}
