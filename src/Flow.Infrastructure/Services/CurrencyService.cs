using AutoMapper;
using AutoMapper.QueryableExtensions;
using Flow.Application.Contracts.Persistence;
using Flow.Application.Contracts.Services;
using Flow.Application.Exceptions;
using Flow.Application.Models.Currency;
using Flow.Domain.Entities;

using Microsoft.EntityFrameworkCore;

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
        var currency = await _unitOfWork.Currencies.GetByCondition(x => x.Id == id, trackChanges: true)
            .ProjectTo<CurrencyDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);
        return currency is not null ? currency : throw new NotFoundException();
    }

    public Task<List<CurrencyDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return _unitOfWork.Currencies.GetAll()
            .ProjectTo<CurrencyDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
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
        var existingCurrency = await _unitOfWork.Currencies.GetByCondition(x => x.Id == id, trackChanges: true)
            .FirstOrDefaultAsync(cancellationToken);
        if (existingCurrency == null)
            throw new NotFoundException();

        existingCurrency.Code = dto.Code;
        existingCurrency.Name = dto.Name;

        if (dto.IsActive.HasValue)
            existingCurrency.IsActive = dto.IsActive.Value;

        _unitOfWork.Currencies.Update(existingCurrency);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var existingCurrency = await _unitOfWork.Currencies.GetByCondition(x => x.Id == id, trackChanges: true)
            .FirstOrDefaultAsync(cancellationToken);
        if (existingCurrency == null)
            throw new NotFoundException();

        _unitOfWork.Currencies.Delete(existingCurrency);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.Currencies.GetByCondition(x => x.Id == id).AnyAsync(cancellationToken);
    }

    public Task<bool> ExistsAsync(string code, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.Currencies.GetByCondition(x => x.Code == code).AnyAsync(cancellationToken);
    }
}
