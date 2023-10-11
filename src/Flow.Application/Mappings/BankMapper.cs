using Flow.Application.Models.Bank;
using Riok.Mapperly.Abstractions;

namespace Flow.Application.Mappings;

[Mapper]
public partial class BankMapper
{
    public partial BankDto Map(Bank bank);

    public partial List<BankDto> Map(List<Bank> banks);

    public partial Bank Map(CreateBankDto createBankDto);

    public partial void Map(Bank bank, UpdateBankDto updateBankDto);
}
