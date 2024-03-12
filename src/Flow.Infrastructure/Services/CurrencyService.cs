using Flow.Application.Models.Currency;
using Flow.Domain.Currencies;

namespace Flow.Infrastructure.Services;

internal sealed class CurrencyService : ICurrencyService
{
    private readonly CurrencyMapper _mapper;

    private readonly TimeProvider _timeProvider;
    private readonly IUnitOfWork _unitOfWork;

    public CurrencyService(IUnitOfWork unitOfWork, TimeProvider timeProvider)
    {
        ArgumentNullException.ThrowIfNull(unitOfWork);

        _unitOfWork = unitOfWork;
        _timeProvider = timeProvider;
        _mapper = new CurrencyMapper();
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

    public async Task<CurrencyDto> CreateAsync(CreateCurrencyDto createCurrencyDto,
        CancellationToken cancellationToken = default)
    {
        var createDate = _timeProvider.GetUtcNow().UtcDateTime;
        var currencyCode = CurrencyCode.Create(createCurrencyDto.Code);
        var currency = Currency.Create(currencyCode.Value, createDate);

        _unitOfWork.Currencies.Create(currency.Value);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map(currency.Value);
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
        return _unitOfWork.Currencies.ExistsAsync(x => x.Code.Value == code, cancellationToken);
    }
}