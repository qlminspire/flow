using AutoMapper;
using Flow.Api.Contracts.Requests.CashAccount;
using Flow.Api.Contracts.Responses.CashAccount;
using Flow.Application.Contracts.Services;
using Flow.Application.Models.CashAccount;
using Microsoft.AspNetCore.Mvc;

namespace Flow.Api.Controllers.Finance;

public class CashAccountsController : BaseController
{
    private readonly ICashAccountService _cashAccountService;
    private readonly IMapper _mapper;

    public CashAccountsController(ICashAccountService bankAccountService, IMapper mapper)
    {
        _cashAccountService = bankAccountService;
        _mapper = mapper;
    }

    [HttpGet("{id:guid}", Name = "GetCashAccountAsync")]
    public async Task<IResult> GetCashAccountAsync(Guid id, CancellationToken cancellationToken)
    {
        var account = await _cashAccountService.GetAsync(UserId, id, cancellationToken);
        var response = _mapper.Map<CashAccountResponse>(account);
        return Results.Ok(response);
    }

    [HttpGet]
    public async Task<IResult> GetCashAccountsAsync(CancellationToken cancellationToken)
    {
        var accounts = await _cashAccountService.GetAllAsync(UserId, cancellationToken);
        var response = _mapper.Map<ICollection<CashAccountResponse>>(accounts);
        return Results.Ok(response);
    }

    [HttpPost]
    public async Task<IResult> CreateCashAccountAsync(CreateCashAccountRequest request, CancellationToken cancellationToken)
    {
        var createCashAccountDto = _mapper.Map<CreateCashAccountDto>(request);
        var createdCashAccount = await _cashAccountService.CreateAsync(UserId, createCashAccountDto, cancellationToken);
        var response = _mapper.Map<CashAccountResponse>(createdCashAccount);
        return Results.CreatedAtRoute("GetCashAccountAsync", new { response.Id }, response);
    }
}
