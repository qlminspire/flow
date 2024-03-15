﻿using Flow.Application.Models.BankAccount;

namespace Flow.Application.Services;

public interface IBankAccountService
{
    Task<BankAccountDto> GetForUserAsync(Guid userId, Guid bankAccountId, CancellationToken cancellationToken = default);

    Task<List<BankAccountDto>> GetAllForUserAsync(Guid userId, CancellationToken cancellationToken = default);

    Task<BankAccountDto> CreateAsync(Guid userId, CreateBankAccountDto createBankAccountDto, CancellationToken cancellationToken = default);
    
    Task DeleteAsync(Guid userId, Guid bankAccountId, CancellationToken cancellationToken = default);
}
