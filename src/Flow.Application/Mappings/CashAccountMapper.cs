using Flow.Application.Models.CashAccount;
using Flow.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Flow.Application.Mapperly;

[Mapper]
public partial class CashAccountMapper
{
    public partial CashAccountDto Map(CashAccount cashAccount);

    public partial List<CashAccountDto> Map(List<CashAccount> cashAccounts);

    public partial CashAccount Map(CreateCashAccountDto createCashAccountDto);

    public partial void Map(CashAccount cashAccount, UpdateCashAccountDto updateCashAccountDto);
}
