using Riok.Mapperly.Abstractions;
using Flow.Application.Models.Bank;
using Flow.Contracts.Requests.Bank;
using Flow.Contracts.Responses.Bank;

namespace Flow.Api.Mappings;

[Mapper]
internal partial class BankMapper
{
    public partial BankShortResponse MapToBankShortResponse(BankDto bankDto);

    public partial BankResponse Map(BankDto bankDto);

    public partial ICollection<BankResponse> Map(ICollection<BankDto> banksDto);

    public partial CreateBankDto Map(CreateBankRequest createBankRequest);

    public partial UpdateBankDto Map(UpdateBankRequest updateBankRequest);
}
