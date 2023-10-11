using Flow.Application.Models.BankAccount;
using Riok.Mapperly.Abstractions;

namespace Flow.Application.Mappings;

[Mapper]
public partial class BankAccountMapper
{
    public partial BankAccountDto Map(BankAccount bankAccount);

    public partial List<BankAccountDto> Map(List<BankAccount> bankAccounts);

    public partial BankAccount Map(CreateBankAccountDto createBankAccountDto);

    public partial void Map(BankAccount bankAccount, UpdateBankAccountDto updateBankAccountDto);
}