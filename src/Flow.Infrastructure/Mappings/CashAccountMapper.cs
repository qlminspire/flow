using Riok.Mapperly.Abstractions;

using Flow.Application.Models.CashAccount;

namespace Flow.Infrastructure.Mappings;

[Mapper]
internal partial class CashAccountMapper
{
    public partial CashAccountDto Map(CashAccount cashAccount);

    public partial List<CashAccountDto> Map(List<CashAccount> cashAccounts);

    public partial CashAccount Map(CreateCashAccountDto createCashAccountDto);

    public partial void Map(CashAccount cashAccount, UpdateCashAccountDto updateCashAccountDto);
}
