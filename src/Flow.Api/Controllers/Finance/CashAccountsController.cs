using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using Flow.Api.Models.CashAccount;
using Flow.Business.Models.CashAccount;
using Flow.Business.Services;

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
    public async Task<CashAccountResponse> GetCashAccountAsync(Guid id, CancellationToken cancellationToken)
    {
        var account = await _cashAccountService.GetAsync(UserId, id, cancellationToken);
        return _mapper.Map<CashAccountResponse>(account);
    }

    [HttpGet]
    public async Task<ICollection<CashAccountResponse>> GetCashAccountsAsync(CancellationToken cancellationToken)
    {
        var accounts = await _cashAccountService.GetAllAsync(UserId, cancellationToken);
        return _mapper.Map<ICollection<CashAccountResponse>>(accounts);
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
