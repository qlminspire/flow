using Riok.Mapperly.Abstractions;

using Flow.Api.Contracts.Requests.Debt;
using Flow.Api.Contracts.Responses.Debt;

using Flow.Application.Models.Debt;

namespace Flow.Api.Mappings;

[Mapper]
internal partial class DebtMapper
{
    public partial DebtResponse Map(DebtDto debtDto);

    public partial ICollection<DebtResponse> Map(ICollection<DebtDto> debtsDto);

    public partial CreateDebtDto Map(CreateDebtRequest createDebtRequest);
}
