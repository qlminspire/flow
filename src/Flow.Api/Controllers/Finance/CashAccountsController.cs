using Microsoft.AspNetCore.Mvc;

using Flow.Api.Contracts.Requests.CashAccount;

namespace Flow.Api.Controllers.Finance;

public class CashAccountsController : BaseController
{
    private readonly ICashAccountService _cashAccountService;
    private readonly CashAccountMapper _mapper;

    public CashAccountsController(ICashAccountService bankAccountService)
    {
        _cashAccountService = bankAccountService;
        _mapper = new();
    }

    [HttpGet("{id:guid}", Name = "GetCashAccountAsync")]
    public async Task<IResult> GetCashAccountAsync(Guid id, CancellationToken cancellationToken)
    {
        var account = await _cashAccountService.GetAsync(UserId, id, cancellationToken);
        var response = _mapper.Map(account);
        return Results.Ok(response);
    }

    [HttpGet]
    public async Task<IResult> GetCashAccountsAsync(CancellationToken cancellationToken)
    {
        var accounts = await _cashAccountService.GetAllAsync(UserId, cancellationToken);
        var response = _mapper.Map(accounts);
        return Results.Ok(response);
    }

    [HttpPost]
    public async Task<IResult> CreateCashAccountAsync(CreateCashAccountRequest request, CancellationToken cancellationToken)
    {
        var createCashAccountDto = _mapper.Map(request);
        var createdCashAccount = await _cashAccountService.CreateAsync(UserId, createCashAccountDto, cancellationToken);
        var response = _mapper.Map(createdCashAccount);
        return Results.CreatedAtRoute("GetCashAccountAsync", new { response.Id }, response);
    }
}
