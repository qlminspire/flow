using Flow.Application.Models.Bank;
using Flow.Domain.Banks;
using Riok.Mapperly.Abstractions;

namespace Flow.Infrastructure.Mappings;

[Mapper]
internal partial class BankMapper
{
    public partial BankDto Map(Bank bank);

    public partial List<BankDto> Map(List<Bank> banks);

    private string BankNameToString(BankName bankName) => bankName.Value;
}