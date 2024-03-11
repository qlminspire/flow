using Flow.Application.Models.BankDeposit;
using Flow.Domain.BankDeposits;
using Riok.Mapperly.Abstractions;

namespace Flow.Infrastructure.Mappings;

[Mapper]
internal partial class BankDepositMapper
{
    public partial BankDepositDto Map(BankDeposit bankDeposit);

    public partial List<BankDepositDto> Map(List<BankDeposit> bankDeposits);

    public partial BankDeposit Map(CreateBankDepositDto createBankDepositDto);

    public partial void Map(UpdateBankDepositDto updateBankDepositDto, BankDeposit bankDeposit);
}