using Riok.Mapperly.Abstractions;

using Flow.Application.Models.Debt;

namespace Flow.Infrastructure.Mappings;

[Mapper]
internal partial class DebtMapper
{
    public partial DebtDto Map(Debt debt);

    public partial List<DebtDto> Map(List<Debt> debts);

    public partial Debt Map(CreateDebtDto createDebtDto);

    public partial void Map(Debt debt, UpdateDebtDto updateDebtDto);
}
