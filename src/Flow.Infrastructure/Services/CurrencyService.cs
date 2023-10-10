﻿using AutoMapper;
using Flow.Application.Contracts.Persistence;
using Flow.Application.Contracts.Services;
using Flow.Application.Exceptions;
using Flow.Application.Models.Currency;
using Flow.Domain.Entities;

namespace Flow.Infrastructure.Services;

internal sealed class CurrencyService : ICurrencyService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CurrencyService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CurrencyDto> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var currency = await _unitOfWork.Currencies.GetByIdAsync(id, cancellationToken)
            ?? throw new NotFoundException();
        return _mapper.Map<CurrencyDto>(currency);
    }

    public async Task<List<CurrencyDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var currencies = await _unitOfWork.Currencies.GetAllAsync(cancellationToken);
        return _mapper.Map<List<CurrencyDto>>(currencies);
    }

    public async Task<CurrencyDto> CreateAsync(CreateCurrencyDto dto, CancellationToken cancellationToken = default)
    {
        var currency = _mapper.Map<Currency>(dto);

        _unitOfWork.Currencies.Create(currency);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CurrencyDto>(currency);
    }

    public async Task UpdateAsync(Guid id, UpdateCurrencyDto dto, CancellationToken cancellationToken = default)
    {
        var existingCurrency = await _unitOfWork.Currencies.GetByIdAsync(id, cancellationToken)
            ?? throw new NotFoundException();

        existingCurrency.Code = dto.Code;
        existingCurrency.Name = dto.Name;

        if (dto.IsActive.HasValue)
            existingCurrency.IsActive = dto.IsActive.Value;

        _unitOfWork.Currencies.Update(existingCurrency);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var existingCurrency = await _unitOfWork.Currencies.GetByIdAsync(id, cancellationToken)
            ?? throw new NotFoundException();

        _unitOfWork.Currencies.Delete(existingCurrency);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.Currencies.ExistsAsync(x => x.Id == id, cancellationToken);
    }

    public Task<bool> ExistsAsync(string code, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.Currencies.ExistsAsync(x => x.Code == code, cancellationToken);
    }
}
