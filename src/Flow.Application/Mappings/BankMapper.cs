﻿using Flow.Application.Models.Bank;
using Flow.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Flow.Application.Mapperly;

[Mapper]
public partial class BankMapper
{
    public partial BankDto Map(Bank bank);

    public partial List<BankDto> Map(List<Bank> banks);

    public partial Bank Map(CreateBankDto createBankDto);

    public partial void Map(Bank bank, UpdateBankDto updateBankDto);
}
