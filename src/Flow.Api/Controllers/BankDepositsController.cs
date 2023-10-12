using Microsoft.AspNetCore.Mvc;

using Flow.Api.Contracts.Requests.BankDeposit;

namespace Flow.Api.Controllers;

public sealed class BankDepositsController : BaseController
{
    private readonly IBankDepositService _bankDepositService;
    private readonly BankDepositMapper _mapper;

    public BankDepositsController(IBankDepositService bankDepositService)
    {
        _bankDepositService = bankDepositService;
        _mapper = new();
    }

    [HttpGet("{id:guid}", Name = "GetBankDepositAsync")]
    public async Task<IResult> GetBankDepositAsync(Guid id, CancellationToken cancellationToken)
    {
        var deposit = await _bankDepositService.GetAsync(UserId, id, cancellationToken);
        var response = _mapper.Map(deposit);
        return Results.Ok(response);
    }

    [HttpGet]
    public async Task<IResult> GetBankDepositsAsync(CancellationToken cancellationToken)
    {
        var deposits = await _bankDepositService.GetAllAsync(UserId, cancellationToken);
        var response = _mapper.Map(deposits);
        return Results.Ok(response);
    }

    [HttpPost]
    public async Task<IResult> CreateBankDepositAsync(CreateBankDepositRequest request, CancellationToken cancellationToken)
    {
        var createDepositDto = _mapper.Map(request);
        var createdDeposit = await _bankDepositService.CreateAsync(UserId, createDepositDto, cancellationToken);
        var response = _mapper.Map(createdDeposit);
        return Results.CreatedAtRoute("GetBankDepositAsync", new { response.Id }, response);
    }
}
