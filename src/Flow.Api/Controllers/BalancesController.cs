using Flow.Contracts.Responses.Balance;
using Microsoft.AspNetCore.Mvc;

namespace Flow.Api.Controllers;

public class BalancesController : BaseController
{
    private readonly ICalculatedBalanceService _balanceService;
    private readonly BalanceMapper _mapper;

    public BalancesController(ICalculatedBalanceService balanceService)
    {
        _balanceService = balanceService;
        _mapper = new();
    }

    /// <summary>
    /// Get user calculated balance
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET: api/balances
    /// </remarks>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The user calculated balance</returns>
    [HttpGet]
    [ProducesResponseType(typeof(CalculatedBalanceResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
    public async Task<IResult> GetCalculatedBalanceAsync(CancellationToken cancellationToken)
    {
        var calculatedBalance = await _balanceService.GetAsync(UserId, cancellationToken);
        return Results.Ok(_mapper.Map(calculatedBalance));
    }
}
