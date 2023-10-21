using Riok.Mapperly.Abstractions;
using Flow.Application.Models.Balance;
using Flow.Contracts.Responses.Balance;

namespace Flow.Api.Mappings;

[Mapper]
internal partial class BalanceMapper
{
    public partial BalanceResponse Map(BalanceDto balanceDto);

    public partial CalculatedBalanceResponse Map(CalculatedBalanceDto calculatedBalanceDto);
}
