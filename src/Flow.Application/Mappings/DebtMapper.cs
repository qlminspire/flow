using Flow.Application.Models.Debt;
using Flow.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Flow.Application.Mapperly;

[Mapper]
public partial class DebtMapper
{
    public partial DebtDto Map(Debt debt);

    public partial List<DebtDto> Map(List<Debt> debts);

    public partial Debt Map(CreateDebtDto createDebtDto);

    public partial void Map(Debt debt, UpdateDebtDto updateDebtDto);
}
