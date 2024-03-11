using Flow.Application.Models.Debt;
using Flow.Domain.Debts;
using Riok.Mapperly.Abstractions;

namespace Flow.Infrastructure.Mappings;

[Mapper]
internal partial class DebtMapper
{
    public partial DebtDto Map(Debt debt);

    public partial List<DebtDto> Map(List<Debt> debts);

    public partial Debt Map(CreateDebtDto createDebtDto);

    public partial void Map(UpdateDebtDto updateDebtDto, Debt debt);
}