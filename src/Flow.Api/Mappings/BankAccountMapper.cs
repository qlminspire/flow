using Flow.Application.Models.BankAccount;
using Flow.Contracts.Requests.BankAccount;
using Flow.Contracts.Responses.BankAccount;
using Riok.Mapperly.Abstractions;

namespace Flow.Api.Mappings;

[Mapper]
internal sealed partial class BankAccountMapper
{
    public partial BankAccountResponse Map(BankAccountDto bankAccountDto);

    public partial ICollection<BankAccountResponse> Map(ICollection<BankAccountDto> bankAccountsDto);

    public partial CreateBankAccountDto Map(CreateBankAccountRequest createBankAccountRequest);
}