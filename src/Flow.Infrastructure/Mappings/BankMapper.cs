﻿using Flow.Application.Models.Bank;
using Flow.Domain.Banks;
using Riok.Mapperly.Abstractions;

namespace Flow.Infrastructure.Mappings;

[Mapper]
internal partial class BankMapper
{
    public partial BankDto Map(Bank bank);

    public partial List<BankDto> Map(List<Bank> banks);

    public partial Bank Map(CreateBankDto createBankDto);

    public partial void Map(UpdateBankDto updateBankDto, Bank bank);
}