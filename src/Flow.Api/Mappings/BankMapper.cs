using Flow.Application.Models.Bank;
using Flow.Contracts.Requests.Bank;
using Flow.Contracts.Responses.Bank;
using Riok.Mapperly.Abstractions;

namespace Flow.Api.Mappings;

[Mapper]
internal partial class BankMapper
{
    public partial BankResponse Map(BankDto bankDto);

    public partial ICollection<BankResponse> Map(ICollection<BankDto> banksDto);

    public partial CreateBankDto Map(CreateBankRequest createBankRequest);
}