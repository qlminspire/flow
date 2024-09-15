using Flow.Application.Models.BankDeposit;
using Flow.Contracts.Requests.BankDeposit;
using Flow.Contracts.Responses.BankDeposit;
using Riok.Mapperly.Abstractions;

namespace Flow.Api.Mappings;

[Mapper]
internal sealed partial class BankDepositMapper
{
    public partial BankDepositResponse Map(BankDepositDto bankDepositDto);

    public partial ICollection<BankDepositResponse> Map(ICollection<BankDepositDto> bankDepositsDto);

    public partial CreateBankDepositDto Map(CreateBankDepositRequest createBankDepositRequest);
}