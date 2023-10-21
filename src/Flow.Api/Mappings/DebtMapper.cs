using Riok.Mapperly.Abstractions;
using Flow.Application.Models.Debt;
using Flow.Contracts.Requests.Debt;
using Flow.Contracts.Responses.Debt;

namespace Flow.Api.Mappings;

[Mapper]
internal partial class DebtMapper
{
    public partial DebtResponse Map(DebtDto debtDto);

    public partial ICollection<DebtResponse> Map(ICollection<DebtDto> debtsDto);

    public partial CreateDebtDto Map(CreateDebtRequest createDebtRequest);
}
