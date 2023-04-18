using AutoMapper;
using Flow.Api.Models.Debt;
using Flow.Application.Models.Debt;
using Flow.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Flow.Api.Controllers.Finance;

public class DebtsController : BaseController
{
    private readonly IDebtService _debtService;
    private readonly IMapper _mapper;

    public DebtsController(IDebtService debtService, IMapper mapper)
    {
        _debtService = debtService;
        _mapper = mapper;
    }

    [HttpGet("{id:guid}", Name = "GetDebtAsync")]
    public async Task<IResult> GetDebtAsync(Guid id, CancellationToken cancellationToken)
    {
        var debt = await _debtService.GetAsync(UserId, id, cancellationToken);
        var response = _mapper.Map<DebtResponse>(debt);
        return Results.Ok(response);
    }

    [HttpGet]
    public async Task<IResult> GetDebtsAsync(CancellationToken cancellationToken)
    {
        var debts = await _debtService.GetAllAsync(UserId, cancellationToken);
        var response = _mapper.Map<ICollection<DebtResponse>>(debts);
        return Results.Ok(response);
    }

    [HttpPost]
    public async Task<IResult> CreateDebtAsync(CreateDebtRequest request, CancellationToken cancellationToken)
    {
        var createDebtDto = _mapper.Map<CreateDebtDto>(request);
        var createdDebt = await _debtService.CreateAsync(UserId, createDebtDto, cancellationToken);
        var response = _mapper.Map<DebtResponse>(createdDebt);
        return Results.CreatedAtRoute("GetDebtAsync", new { response.Id }, response);
    }
}
