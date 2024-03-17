using Flow.Application.Models.Currency;
using Flow.Application.Shared.Validation;
using Flow.Domain.Currencies;

namespace Flow.Infrastructure.Services;

internal sealed class CurrencyService : ICurrencyService
{
    private readonly CurrencyMapper _mapper;

    private readonly TimeProvider _timeProvider;
    private readonly IUnitOfWork _unitOfWork;

    public CurrencyService(IUnitOfWork unitOfWork, TimeProvider timeProvider)
    {
        _unitOfWork = unitOfWork;
        _timeProvider = timeProvider;
        _mapper = new CurrencyMapper();
    }

    public async Task<CurrencyDto> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var currencyId = new CurrencyId(id);
        var currency = await _unitOfWork.Currencies.GetByIdAsync(currencyId, cancellationToken)
                       ?? throw new NotFoundException(currencyId);

        return _mapper.Map(currency);
    }

    public async Task<List<CurrencyDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var currencies = await _unitOfWork.Currencies.GetAllAsync(cancellationToken);
        return _mapper.Map(currencies);
    }

    public async Task<CurrencyDto> CreateAsync(CreateCurrencyDto createCurrencyDto,
        CancellationToken cancellationToken = default)
    {
        var currencyCode = Ensure.Result.Success(CurrencyCode.Create(createCurrencyDto.Code));
        var createdAt = _timeProvider.GetUtcNow().UtcDateTime;

        var currencyExists = await _unitOfWork.Currencies.ExistsAsync(x => x.Code == currencyCode, cancellationToken);
        Ensure.NotExists<Currency>(currencyExists);

        var currency = Ensure.Result.Success(Currency.Create(currencyCode, createdAt));

        _unitOfWork.Currencies.Create(currency);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map(currency);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var currencyId = new CurrencyId(id);
        var currency = await _unitOfWork.Currencies.GetByIdAsync(currencyId, cancellationToken)
                       ?? throw new NotFoundException(currencyId);

        _unitOfWork.Currencies.Delete(currency);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.Currencies.ExistsAsync(x => x.Id.Value == id, cancellationToken);
    }

    public Task<bool> ExistsAsync(string code, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.Currencies.ExistsAsync(x => x.Code.Value == code, cancellationToken);
    }
}