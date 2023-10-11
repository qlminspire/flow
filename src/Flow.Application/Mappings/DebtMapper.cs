using Flow.Application.Models.Debt;
using Riok.Mapperly.Abstractions;

namespace Flow.Application.Mappings;

[Mapper]
public partial class DebtMapper
{
    public partial DebtDto Map(Debt debt);

    public partial List<DebtDto> Map(List<Debt> debts);

    public partial Debt Map(CreateDebtDto createDebtDto);

    public partial void Map(Debt debt, UpdateDebtDto updateDebtDto);
}
