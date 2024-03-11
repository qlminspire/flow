using Flow.Application.Models.CashAccount;
using Flow.Domain.Accounts;
using Riok.Mapperly.Abstractions;

namespace Flow.Infrastructure.Mappings;

[Mapper]
internal partial class CashAccountMapper
{
    public partial CashAccountDto Map(CashAccount cashAccount);

    public partial List<CashAccountDto> Map(List<CashAccount> cashAccounts);

    public partial CashAccount Map(CreateCashAccountDto createCashAccountDto);

    public partial void Map(UpdateCashAccountDto updateCashAccountDto, CashAccount cashAccount);
}