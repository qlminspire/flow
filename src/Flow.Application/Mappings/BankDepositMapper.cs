using Flow.Application.Models.BankDeposit;
using Riok.Mapperly.Abstractions;

namespace Flow.Application.Mappings;

[Mapper]
public partial class BankDepositMapper
{
    public partial BankDepositDto Map(BankDeposit bankDeposit);

    public partial List<BankDepositDto> Map(List<BankDeposit> bankDeposits);

    public partial BankDeposit Map(CreateBankDepositDto createBankDepositDto);

    public partial void Map(BankDeposit bankDeposit, UpdateBankDepositDto updateBankDepositDto);
}