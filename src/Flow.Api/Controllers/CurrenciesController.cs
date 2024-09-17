using Flow.Contracts.Requests.Currency;
using Flow.Contracts.Responses.Currency;
using Microsoft.AspNetCore.Mvc;

namespace Flow.Api.Controllers;

public class CurrenciesController : BaseController
{
    private readonly ICurrencyService _currencyService;
    private readonly CurrencyMapper _mapper;

    public CurrenciesController(ICurrencyService currencyService)
    {
        _currencyService = currencyService;
        _mapper = new CurrencyMapper();
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
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IResult> GetCurrencyAsync(Guid id, CancellationToken cancellationToken)
    {
        var currency = await _currencyService.GetAsync(id, cancellationToken);
        return Results.Ok(_mapper.Map(currency));
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
    [ProducesResponseType(typeof(ICollection<CurrencyResponse>), StatusCodes.Status200OK)]
    public async Task<IResult> GetCurrenciesAsync(CancellationToken cancellationToken)
    {
        var currencies = await _currencyService.GetAllAsync(cancellationToken);
        return Results.Ok(_mapper.Map(currencies));
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
    ///     }
    /// </remarks>
    /// <param name="request">The create currency request</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The newly created currency</returns>
    [HttpPost]
    [ProducesResponseType(typeof(CurrencyResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IResult> CreateCurrencyAsync([FromBody] CreateCurrencyRequest request,
        CancellationToken cancellationToken)
    {
        var createCurrencyDto = _mapper.Map(request);
        var currency = await _currencyService.CreateAsync(createCurrencyDto, cancellationToken);
        var response = _mapper.Map(currency);
        return Results.CreatedAtRoute("GetCurrencyAsync", new { response.Id }, response);
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
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IResult> DeleteCurrencyAsync(Guid id, CancellationToken cancellationToken)
    {
        await _currencyService.DeleteAsync(id, cancellationToken);
        return Results.NoContent();
    }
}