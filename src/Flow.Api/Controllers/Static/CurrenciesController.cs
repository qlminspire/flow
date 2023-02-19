using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using Flow.Business.Services;
using Flow.Api.Models.Currency;
using Flow.Business.Models.Currency;

namespace Flow.Api.Controllers.Static;

public class CurrenciesController : BaseController
{
    private readonly ICurrencyService _currencyService;
    private readonly IMapper _mapper;

    public CurrenciesController(ICurrencyService currencyService, IMapper mapper)
    {
        _currencyService = currencyService;
        _mapper = mapper;
    }

    [HttpGet("{id:guid}", Name = "GetCurrencyAsync")]
    public async Task<CurrencyResponse> GetCurrencyAsync(Guid id, CancellationToken cancellationToken)
    {
        var currency = await _currencyService.GetAsync(id, cancellationToken);
        return _mapper.Map<CurrencyResponse>(currency);
    }

    [HttpGet]
    public async Task<ICollection<CurrencyResponse>> GetCurrenciesAsync(CancellationToken cancellationToken)
    {
        var currencies = await _currencyService.GetAllAsync(cancellationToken);
        return _mapper.Map<ICollection<CurrencyResponse>>(currencies);
    }

    [HttpPost]
    public async Task<IResult> CreateCurrencyAsync([FromBody] CreateCurrencyRequest request, CancellationToken cancellationToken)
    {
        var createCurrencyDto = _mapper.Map<CreateCurrencyDto>(request);
        var currency = await _currencyService.CreateAsync(createCurrencyDto, cancellationToken);
        var response = _mapper.Map<CurrencyResponse>(currency);
        return Results.CreatedAtRoute("GetCurrencyAsync", new { response.Id }, response);
    }

    [HttpPut("{id:guid}")]
    public async Task<IResult> UpdateCurrencyAsync(Guid id, [FromBody] UpdateCurrencyRequest request, CancellationToken cancellationToken)
    {
        var updateCurrencyDto = _mapper.Map<UpdateCurrencyDto>(request);
        await _currencyService.UpdateAsync(id, updateCurrencyDto, cancellationToken);
        return Results.Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IResult> DeleteSubscriptionAsync(Guid id, CancellationToken cancellationToken)
    {
        await _currencyService.DeleteAsync(id, cancellationToken);
        return Results.Ok();
    }
}
