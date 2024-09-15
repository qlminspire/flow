using Flow.Application.Models.Balance;
using Flow.Contracts.Responses.Balance;
using Riok.Mapperly.Abstractions;

namespace Flow.Api.Mappings;

[Mapper]
internal sealed partial class BalanceMapper
{
    public partial BalanceResponse Map(BalanceDto balanceDto);

    public partial CalculatedBalanceResponse Map(CalculatedBalanceDto calculatedBalanceDto);
}