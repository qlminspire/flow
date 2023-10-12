using Microsoft.AspNetCore.Mvc;

using Flow.Api.Contracts.Requests.Debt;

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

    [HttpGet("{id:guid}", Name = "GetDebtAsync")]
    public async Task<IResult> GetDebtAsync(Guid id, CancellationToken cancellationToken)
    {
        var debt = await _debtService.GetAsync(UserId, id, cancellationToken);
        var response = _mapper.Map(debt);
        return Results.Ok(response);
    }

    [HttpGet]
    public async Task<IResult> GetDebtsAsync(CancellationToken cancellationToken)
    {
        var debts = await _debtService.GetAllAsync(UserId, cancellationToken);
        var response = _mapper.Map(debts);
        return Results.Ok(response);
    }

    [HttpPost]
    public async Task<IResult> CreateDebtAsync(CreateDebtRequest request, CancellationToken cancellationToken)
    {
        var createDebtDto = _mapper.Map(request);
        var createdDebt = await _debtService.CreateAsync(UserId, createDebtDto, cancellationToken);
        var response = _mapper.Map(createdDebt);
        return Results.CreatedAtRoute("GetDebtAsync", new { response.Id }, response);
    }
}
