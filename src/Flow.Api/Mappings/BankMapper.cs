using Riok.Mapperly.Abstractions;

using Flow.Api.Contracts.Requests.Bank;
using Flow.Api.Contracts.Responses.Bank;
using Flow.Application.Models.Bank;

namespace Flow.Api.Mappings;

[Mapper]
internal partial class BankMapper
{
    public partial BankResponse Map(BankDto bankDto);

    public partial ICollection<BankResponse> Map(ICollection<BankDto> banksDto);

    public partial CreateBankDto Map(CreateBankRequest createBankRequest);

    public partial UpdateBankDto Map(UpdateBankRequest updateBankRequest);
}
