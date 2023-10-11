using Flow.Api.Contracts.Responses.Balance;
using Flow.Application.Models.Balance;
using Riok.Mapperly.Abstractions;

namespace Flow.Api.Mappings;

[Mapper]
internal partial class BalanceMapper
{
    public partial BalanceResponse Map(BalanceDto balanceDto);

    public partial CalculatedBalanceResponse Map(CalculatedBalanceDto calculatedBalanceDto);
}
