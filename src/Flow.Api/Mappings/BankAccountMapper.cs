using Riok.Mapperly.Abstractions;
using Flow.Application.Models.BankAccount;
using Flow.Contracts.Requests.BankAccount;
using Flow.Contracts.Responses.BankAccount;

namespace Flow.Api.Mappings;

[Mapper]
internal partial class BankAccountMapper
{
    public partial BankAccountResponse Map(BankAccountDto bankAccountDto);

    public partial ICollection<BankAccountResponse> Map(ICollection<BankAccountDto> bankAccountsDto);

    public partial CreateBankAccountDto Map(CreateBankAccountRequest createBankAccountRequest);
}
