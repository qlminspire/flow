using Flow.Application.Models.BankAccount;
using Flow.Domain.Accounts;
using Riok.Mapperly.Abstractions;

namespace Flow.Infrastructure.Mappings;

[Mapper]
internal partial class BankAccountMapper
{
    public partial BankAccountDto Map(BankAccount bankAccount);

    public partial List<BankAccountDto> Map(List<BankAccount> bankAccounts);

    public partial BankAccount Map(CreateBankAccountDto createBankAccountDto);

    public partial void Map(UpdateBankAccountDto updateBankAccountDto, BankAccount bankAccount);
}