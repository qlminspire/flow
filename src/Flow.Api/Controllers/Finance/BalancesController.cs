using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using Flow.Api.Models.Balance;
using Flow.Business.Services;

namespace Flow.Api.Controllers.Finance;

public class BalancesController: BaseController
{
    private readonly ICalculatedBalanceService _balanceService;
    private readonly IMapper _mapper;

    public BalancesController(ICalculatedBalanceService balanceService, IMapper mapper)
    {
        _balanceService = balanceService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IResult> GetCalculatedBalanceAsync(CancellationToken cancellationToken)
    {
        var calculatedBalance = await _balanceService.GetAsync(UserId, cancellationToken);
        var response = _mapper.Map<CalculatedBalanceResponse>(calculatedBalance);
        return Results.Ok(response);
    }
}
