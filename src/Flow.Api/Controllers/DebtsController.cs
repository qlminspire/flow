using Microsoft.AspNetCore.Mvc;

using Flow.Api.Contracts.Requests.Debt;
using Flow.Api.Contracts.Responses.Debt;
using Flow.Api.Contracts.Responses.Currency;

namespace Flow.Api.Controllers;

public class DebtsController : BaseController
{
    private readonly IDebtService _debtService;
    private readonly DebtMapper _mapper;

    public DebtsController(IDebtService debtService)
    {
        _debtService = debtService;
        _mapper = new();
    }

    /// <summary>
    /// Get user debt
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET: api/debts/fff3ccff-8847-464b-b851-25b805659ae5
    /// </remarks>
    /// <param name="id">The Id of the debt</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The user debt</returns>
    [HttpGet("{id:guid}", Name = "GetDebtAsync")]
    [ProducesResponseType(typeof(DebtResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status404NotFound)]
    public async Task<IResult> GetDebtAsync(Guid id, CancellationToken cancellationToken)
    {
        var debt = await _debtService.GetAsync(UserId, id, cancellationToken);
        return Results.Ok(_mapper.Map(debt));
    }

    /// <summary>
    /// Get the list of user debts
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET: api/debts
    /// </remarks>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The list of user debts</returns>
    [HttpGet]
    [ProducesResponseType(typeof(ICollection<DebtResponse>), StatusCodes.Status200OK)]
    public async Task<IResult> GetDebtsAsync(CancellationToken cancellationToken)
    {
        var debts = await _debtService.GetAllAsync(UserId, cancellationToken);
        return Results.Ok(_mapper.Map(debts));
    }

    /// <summary>
    /// Create user debt
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST: api/debts
    ///     {
    ///         "name": "PS5",
    ///         "amount": 1000,
    ///         "currencyId": "e883faf0-e8b1-48cb-a527-ae0cfe350dd6"
    ///     }
    /// </remarks>
    /// <param name="request">The create debt request</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The newly created user debt</returns>
    [HttpPost]
    [ProducesResponseType(typeof(DebtResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status404NotFound)]
    public async Task<IResult> CreateDebtAsync(CreateDebtRequest request, CancellationToken cancellationToken)
    {
        var createDebtDto = _mapper.Map(request);
        var createdDebt = await _debtService.CreateAsync(UserId, createDebtDto, cancellationToken);
        var response = _mapper.Map(createdDebt);
        return Results.CreatedAtRoute("GetDebtAsync", new { response.Id }, response);
    }
}
