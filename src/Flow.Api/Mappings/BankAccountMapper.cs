using Riok.Mapperly.Abstractions;

using Flow.Api.Contracts.Requests.BankAccount;
using Flow.Api.Contracts.Responses.BankAccount;

using Flow.Application.Models.BankAccount;

namespace Flow.Api.Mappings;

[Mapper]
internal partial class BankAccountMapper
{
    public partial BankAccountResponse Map(BankAccountDto bankAccountDto);

    public partial ICollection<BankAccountResponse> Map(ICollection<BankAccountDto> bankAccountsDto);

    public partial CreateBankAccountDto Map(CreateBankAccountRequest createBankAccountRequest);
}
