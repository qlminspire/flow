using Flow.Api.Contracts.Requests.PlannedExpense;
using Flow.Api.Contracts.Responses.PlannedExpense;
using Flow.Api.Mappings;
using Flow.Api.Models;
using Flow.Application.Contracts.Services;
using Flow.Application.Models.PlannedExpense;
using Microsoft.AspNetCore.Mvc;

namespace Flow.Api.Controllers.Finance;

public class PlannedExpensesController : BaseController
{
    private readonly IPlannedExpenseService _plannedExpenseService;
    private readonly PlannedExpenseMapper _mapper;

    public PlannedExpensesController(IPlannedExpenseService plannedExpenseService)
    {
        _plannedExpenseService = plannedExpenseService;
        _mapper = new();
    }

    /// <summary>
    /// Gets planned expense
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
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
    public async Task<IResult> GetPlannedExpenseAsync(Guid id, CancellationToken cancellationToken)
    {
        var plannedExpense = await _plannedExpenseService.GetAsync(UserId, id, cancellationToken);
        var response = _mapper.Map(plannedExpense);
        return Results.Ok(response);
    }

    /// <summary>
    /// Gets all planned expenses
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
        var response = _mapper.Map(plannedExpenses);
        return Results.Ok(response);
    }

    /// <summary>
    /// Gets the list of planned expenses for current month
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET api/plannedExpenses/monthly
    /// </remarks>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The list of planned expenses for current month</returns>
    [HttpGet("monthly")]
    [ProducesResponseType(typeof(MonthlyPlannedExpensesResponse), StatusCodes.Status200OK)]

    public async Task<IResult> GetMonthlyPlannedExpensesAsync(CancellationToken cancellationToken)
    {
        var plannedExpenses = await _plannedExpenseService.GetAllForMonthAsync(UserId, cancellationToken);
        var response = _mapper.Map(plannedExpenses);
        return Results.Ok(response);
    }

    /// <summary>
    /// Creates planned expense
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     POST: api/plannedExpenses
    ///     {
    ///         "name": "IPhone 14 Pro",
    ///         "amount": 1200,
    ///         "currencyId": "e883faf0-e8b1-48cb-a527-ae0cfe350dd6",
    ///         "expenseDate": "2023-04-23"
    ///     }
    /// </remarks>
    /// <param name="request">The planned expense create request</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The newly created planned expense</returns>
    [HttpPost]
    [ProducesResponseType(typeof(PlannedExpenseResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
    public async Task<IResult> CreatePlannedExpenseAsync([FromBody] CreatePlannedExpenseRequest request, CancellationToken cancellationToken)
    {
        var createPlannedExpenseDto = _mapper.Map(request);
        var plannedExpense = await _plannedExpenseService.CreateAsync(UserId, createPlannedExpenseDto, cancellationToken);
        var response = _mapper.Map(plannedExpense);
        return Results.CreatedAtRoute("GetPlannedExpenseAsync", new { response.Id }, response);
    }

    /// <summary>
    /// Update planned expense
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     PUT: api/plannedExpenses/485834cf-2488-44fe-a24d-dafc2d097830
    ///     {
    ///         "name": "Travel",
    ///         "amount": 350,
    ///         "currencyId": "e883faf0-e8b1-48cb-a527-ae0cfe350dd6",
    ///         "expenseDate": "2023-04-23"
    ///     }
    /// </remarks>
    /// <param name="id">The Id of the planned expense</param>
    /// <param name="request">The planned expense update request</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns></returns>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
    public async Task<IResult> UpdatePlannedExpenseAsync(Guid id, [FromBody] UpdatePlannedExpenseRequest request, CancellationToken cancellationToken)
    {
        var updatePlannedExpenseDto = _mapper.Map(request);
        await _plannedExpenseService.UpdateAsync(UserId, id, updatePlannedExpenseDto, cancellationToken);
        return Results.NoContent();
    }

    /// <summary>
    /// Deletes planned expense
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
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
    public async Task<IResult> DeletePlannedExpenseAsync(Guid id, CancellationToken cancellationToken)
    {
        await _plannedExpenseService.DeleteAsync(UserId, id, cancellationToken);
        return Results.NoContent();
    }
}
