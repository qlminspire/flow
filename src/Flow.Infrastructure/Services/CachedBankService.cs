﻿using Flow.Application.Models.Bank;
using Flow.Infrastructure.Constants;
using Microsoft.Extensions.Caching.Memory;

namespace Flow.Infrastructure.Services;

internal sealed class CachedBankService : IBankService
{
    private readonly IBankService _bankService;

    private readonly IMemoryCache _memoryCache;
    
    private static readonly TimeSpan CachePeriod = TimeSpan.FromMinutes(15);
    
    public CachedBankService(IBankService bankService, IMemoryCache memoryCache)
    {
        ArgumentNullException.ThrowIfNull(bankService);
        ArgumentNullException.ThrowIfNull(memoryCache);
        
        _bankService = bankService;
        _memoryCache = memoryCache;
    }

    public async Task<BankDto> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var bank =  await _memoryCache.GetOrCreateAsync(CacheKeys.BankById(id), cacheEntry =>
        {
            cacheEntry.SetAbsoluteExpiration(CachePeriod);
            
            return _bankService.GetAsync(id, cancellationToken);
        });

        return bank ?? throw new NotFoundException();
    }

    public async Task<List<BankDto>> GetAsync(CancellationToken cancellationToken = default)
    {
        var banks = await _memoryCache.GetOrCreateAsync(CacheKeys.Banks(), cacheEntry =>
        {
            cacheEntry.SetAbsoluteExpiration(CachePeriod); 
            
            return _bankService.GetAsync(cancellationToken);
        });
        return banks ?? new List<BankDto>();
    }

    public Task<BankDto> CreateAsync(CreateBankDto createBankDto, CancellationToken cancellationToken = default)
    {
        _memoryCache.Remove(CacheKeys.Banks());
        
        return _bankService.CreateAsync(createBankDto, cancellationToken);
    }

    public Task UpdateAsync(Guid id, UpdateBankDto updateBankDto, CancellationToken cancellationToken = default)
    {
        _memoryCache.Remove(CacheKeys.BankById(id));
        _memoryCache.Remove(CacheKeys.Banks());
        
        return _bankService.UpdateAsync(id, updateBankDto, cancellationToken);
    }

    public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        _memoryCache.Remove(CacheKeys.BankById(id));
        _memoryCache.Remove(CacheKeys.Banks());
        
        return _bankService.DeleteAsync(id, cancellationToken);
    }

    public Task<bool> ExistsAsync(string name, CancellationToken cancellationToken = default)
    {
        return _bankService.ExistsAsync(name, cancellationToken);
    }
}