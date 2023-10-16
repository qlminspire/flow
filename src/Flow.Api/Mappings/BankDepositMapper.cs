using Riok.Mapperly.Abstractions;

using Flow.Api.Contracts.Requests.BankDeposit;
using Flow.Api.Contracts.Responses.BankDeposit;

using Flow.Application.Models.BankDeposit;

namespace Flow.Api.Mappings;

[Mapper]
internal partial class BankDepositMapper
{
    public partial BankDepositResponse Map(BankDepositDto bankDepositDto);

    public partial ICollection<BankDepositResponse> Map(ICollection<BankDepositDto> bankDepositsDto);

    public partial CreateBankDepositDto Map(CreateBankDepositRequest createBankDepositRequest);
}
