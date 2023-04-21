using AutoMapper;
using AutoMapper.QueryableExtensions;

using Flow.Application.Models.Currency;
using Flow.Application.Persistence;
using Flow.Application.Services;
using Flow.Domain.Entities;

using Microsoft.EntityFrameworkCore;

using OneOf;
using OneOf.Types;

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

    public async Task<OneOf<CurrencyDto, NotFound>> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var currency = await _unitOfWork.Currencies.GetByCondition(x => x.Id == id, trackChanges: true)
            .ProjectTo<CurrencyDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);
        return currency != null ? currency : new NotFound();
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

    public async Task<OneOf<Success, NotFound>> UpdateAsync(Guid id, UpdateCurrencyDto dto, CancellationToken cancellationToken = default)
    {
        var existingCurrency = await _unitOfWork.Currencies.GetByCondition(x => x.Id == id, trackChanges: true)
            .FirstOrDefaultAsync(cancellationToken);
        if (existingCurrency == null)
            return new NotFound();

        existingCurrency.Code = dto.Code;
        existingCurrency.Name = dto.Name;

        if (dto.IsActive.HasValue)
            existingCurrency.IsActive = dto.IsActive.Value;

        _unitOfWork.Currencies.Update(existingCurrency);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new Success();
    }

    public async Task<OneOf<Success, NotFound>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var existingCurrency = await _unitOfWork.Currencies.GetByCondition(x => x.Id == id, trackChanges: true)
            .FirstOrDefaultAsync(cancellationToken);
        if (existingCurrency == null)
            return new NotFound();

        _unitOfWork.Currencies.Delete(existingCurrency);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new Success();
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
