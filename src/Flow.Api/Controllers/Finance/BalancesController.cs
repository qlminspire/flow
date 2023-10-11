using Flow.Api.Contracts.Responses.Balance;
using Flow.Api.Mappings;
using Flow.Api.Models;
using Flow.Application.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace Flow.Api.Controllers.Finance;

public class BalancesController : BaseController
{
    private readonly ICalculatedBalanceService _balanceService;
    private readonly BalanceMapper _mapper;

    public BalancesController(ICalculatedBalanceService balanceService)
    {
        _balanceService = balanceService;
        _mapper = new();
    }

    [HttpGet]
    [ProducesResponseType(typeof(CalculatedBalanceResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
    public async Task<IResult> GetCalculatedBalanceAsync(CancellationToken cancellationToken)
    {
        var calculatedBalance = await _balanceService.GetAsync(UserId, cancellationToken);
        var response = _mapper.Map(calculatedBalance);
        return Results.Ok(response);
    }
}
