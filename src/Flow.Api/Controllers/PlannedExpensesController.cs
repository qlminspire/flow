using Flow.Contracts.Requests.PlannedExpense;
using Flow.Contracts.Responses.PlannedExpense;
using Microsoft.AspNetCore.Mvc;

namespace Flow.Api.Controllers;

public class PlannedExpensesController : BaseController
{
    private readonly PlannedExpenseMapper _mapper;
    private readonly IPlannedExpenseService _plannedExpenseService;

    public PlannedExpensesController(IPlannedExpenseService plannedExpenseService)
    {
        _plannedExpenseService = plannedExpenseService;
        _mapper = new PlannedExpenseMapper();
    }

    /// <summary>
    /// Get user planned expense
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET: api/plannedExpenses/485834cf-2488-44fe-a24d-dafc2d097830
    /// </remarks>
    /// <param name="id">The Id of planned expense</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The planned expense</returns>
    [HttpGet("{id:guid}", Name = "GetPlannedExpenseAsync")]
    [ProducesResponseType(typeof(PlannedExpenseResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IResult> GetPlannedExpenseAsync(Guid id, CancellationToken cancellationToken)
    {
        var plannedExpense = await _plannedExpenseService.GetAsync(UserId, id, cancellationToken);
        return Results.Ok(_mapper.Map(plannedExpense));
    }

    /// <summary>
    /// Gets all planned expenses for user
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET: api/plannedExpenses
    /// </remarks>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The planned expenses</returns>
    [HttpGet]
    [ProducesResponseType(typeof(ICollection<PlannedExpenseResponse>), StatusCodes.Status200OK)]
    public async Task<IResult> GetPlannedExpensesAsync(CancellationToken cancellationToken)
    {
        var plannedExpenses = await _plannedExpenseService.GetAllAsync(UserId, cancellationToken);
        return Results.Ok(_mapper.Map(plannedExpenses));
    }

    /// <summary>
    /// Gets the list of planned expenses for current month for user
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET api/plannedExpenses/monthly/total/usd
    /// </remarks>
    /// <param name="currency">The currency</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The list of planned expenses for current month</returns>
    [HttpGet("Monthly/Total/{currency}")]
    [ProducesResponseType(typeof(MonthlyPlannedExpensesResponse), StatusCodes.Status200OK)]
    public async Task<IResult> GetMonthlyPlannedExpensesAsync(string currency, CancellationToken cancellationToken)
    {
        var plannedExpenses = await _plannedExpenseService.GetMonthlyTotalAsync(UserId, currency, cancellationToken);
        return Results.Ok(_mapper.Map(plannedExpenses));
    }

    /// <summary>
    /// Creates user planned expense
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST: api/plannedExpenses
    ///     {
    ///         "name": "IPhone 14 Pro",
    ///         "amount": 1200,
    ///         "currency": "BYN"
    ///     }
    /// </remarks>
    /// <param name="request">The planned expense create request</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The newly created planned expense</returns>
    [HttpPost]
    [ProducesResponseType(typeof(PlannedExpenseResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IResult> CreatePlannedExpenseAsync([FromBody] CreatePlannedExpenseRequest request,
        CancellationToken cancellationToken)
    {
        var createPlannedExpenseDto = _mapper.Map(request);
        var plannedExpense =
            await _plannedExpenseService.CreateAsync(UserId, createPlannedExpenseDto, cancellationToken);
        var response = _mapper.Map(plannedExpense);
        return Results.CreatedAtRoute("GetPlannedExpenseAsync", new { response.Id }, response);
    }

    /// <summary>
    /// Delete user planned expense
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     DELETE: api/plannedExpenses/485834cf-2488-44fe-a24d-dafc2d097830
    /// </remarks>
    /// <param name="id">The Id of the planned expense</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns></returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IResult> DeletePlannedExpenseAsync(Guid id, CancellationToken cancellationToken)
    {
        await _plannedExpenseService.DeleteAsync(UserId, id, cancellationToken);
        return Results.NoContent();
    }
}