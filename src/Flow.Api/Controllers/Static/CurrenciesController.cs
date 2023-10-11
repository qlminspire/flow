using AutoMapper;
using Flow.Api.Contracts.Requests.Currency;
using Flow.Api.Contracts.Responses.Currency;
using Flow.Api.Models;
using Flow.Application.Contracts.Services;
using Flow.Application.Models.Currency;
using Microsoft.AspNetCore.Mvc;

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

    /// <summary>
    /// Get currency
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET: api/currencies/ff11ff3e-01e3-435c-9e4f-47ecf06778b4
    /// </remarks>
    /// <param name="id">The Id of the currency</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The currency</returns>
    [HttpGet("{id:guid}", Name = "GetCurrencyAsync")]
    [ProducesResponseType(typeof(CurrencyResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
    public async Task<IResult> GetCurrencyAsync(Guid id, CancellationToken cancellationToken)
    {
        var currency = await _currencyService.GetAsync(id, cancellationToken);
        return Results.Ok(_mapper.Map<CurrencyResponse>(currency));
    }

    /// <summary>
    /// Get all currencies
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET: api/currencies
    /// </remarks>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The list of currencies</returns>
    [HttpGet]
    public async Task<IResult> GetCurrenciesAsync(CancellationToken cancellationToken)
    {
        var currencies = await _currencyService.GetAllAsync(cancellationToken);
        var response = _mapper.Map<ICollection<CurrencyResponse>>(currencies);
        return Results.Ok(response);
    }

    /// <summary>
    /// Create currency
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     POST: api/currencies
    ///     {
    ///        "code": "USD",
    ///        "name": "US Dollar",
    ///        "isActive": true
    ///     }
    /// </remarks>
    /// <param name="request">The create currency request</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The newly created currency</returns>
    [HttpPost]
    public async Task<IResult> CreateCurrencyAsync([FromBody] CreateCurrencyRequest request, CancellationToken cancellationToken)
    {
        var createCurrencyDto = _mapper.Map<CreateCurrencyDto>(request);

        var currency = await _currencyService.CreateAsync(createCurrencyDto, cancellationToken);

        var response = _mapper.Map<CurrencyResponse>(currency);
        return Results.CreatedAtRoute("GetCurrencyAsync", new { response.Id }, response);
    }

    /// <summary>
    /// Update currency
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     PUT: api/currencies/ff11ff3e-01e3-435c-9e4f-47ecf06778b4
    ///     {
    ///        "code": "USD",
    ///        "name": "US Dollar",
    ///        "isActive": false
    ///     }
    /// </remarks>
    /// <param name="id">The Id of the currency</param>
    /// <param name="request">The update currency request</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns></returns>
    [HttpPut("{id:guid}")]
    public async Task<IResult> UpdateCurrencyAsync(Guid id, [FromBody] UpdateCurrencyRequest request, CancellationToken cancellationToken)
    {
        var updateCurrencyDto = _mapper.Map<UpdateCurrencyDto>(request);

        await _currencyService.UpdateAsync(id, updateCurrencyDto, cancellationToken);
        return Results.NoContent();
    }

    /// <summary>
    /// Delete currency
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     DELETE: api/currencies/ff11ff3e-01e3-435c-9e4f-47ecf06778b4
    /// </remarks>
    /// <param name="id">The id of the currency</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns></returns>
    [HttpDelete("{id:guid}")]
    public async Task<IResult> DeleteSubscriptionAsync(Guid id, CancellationToken cancellationToken)
    {
        await _currencyService.DeleteAsync(id, cancellationToken);

        return Results.NoContent();
    }
}
