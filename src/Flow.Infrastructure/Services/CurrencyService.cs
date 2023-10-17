using Flow.Application.Models.Currency;

namespace Flow.Infrastructure.Services;

internal sealed class CurrencyService : ICurrencyService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly CurrencyMapper _mapper;

    public CurrencyService(IUnitOfWork unitOfWork)
    {
        ArgumentNullException.ThrowIfNull(unitOfWork);

        _unitOfWork = unitOfWork;
        _mapper = new();
    }

    public async Task<CurrencyDto> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var currency = await _unitOfWork.Currencies.GetByIdAsync(id, cancellationToken)
            ?? throw new NotFoundException();

        return _mapper.Map(currency);
    }

    public async Task<List<CurrencyDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var currencies = await _unitOfWork.Currencies.GetAllAsync(cancellationToken);
        return _mapper.Map(currencies);
    }

    public async Task<CurrencyDto> CreateAsync(CreateCurrencyDto createCurrencyDto, CancellationToken cancellationToken = default)
    {
        var currency = _mapper.Map(createCurrencyDto);

        _unitOfWork.Currencies.Create(currency);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map(currency);
    }

    public async Task UpdateAsync(Guid id, UpdateCurrencyDto updateCurrencyDto, CancellationToken cancellationToken = default)
    {
        var currency = await _unitOfWork.Currencies.GetByIdAsync(id, cancellationToken)
            ?? throw new NotFoundException();

        currency.Code = updateCurrencyDto.Code;
        currency.Name = updateCurrencyDto.Name;

        if (updateCurrencyDto.IsActive.HasValue)
            currency.IsActive = updateCurrencyDto.IsActive.Value;

        _unitOfWork.Currencies.Update(currency);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var currency = await _unitOfWork.Currencies.GetByIdAsync(id, cancellationToken)
            ?? throw new NotFoundException();

        _unitOfWork.Currencies.Delete(currency);
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
