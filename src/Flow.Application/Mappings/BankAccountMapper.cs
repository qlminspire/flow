using Flow.Application.Models.BankAccount;
using Flow.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Flow.Application.Mapperly;

[Mapper]
public partial class BankAccountMapper
{
    public partial BankAccountDto Map(BankAccount bankAccount);

    public partial List<BankAccountDto> Map(List<BankAccount> bankAccounts);

    public partial BankAccount Map(CreateBankAccountDto createBankAccountDto);

    public partial void Map(BankAccount bankAccount, UpdateBankAccountDto updateBankAccountDto);
}