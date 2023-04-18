using AutoMapper;
using Flow.Api.Models;
using Flow.Api.Models.BankAccount;
using Flow.Application.Models.BankAccount;
using Flow.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Flow.Api.Controllers.Finance;

public class BankAccountsController : BaseController
{
    private readonly IBankAccountService _bankAccountService;
    private readonly IMapper _mapper;

    public BankAccountsController(IBankAccountService bankAccountService, IMapper mapper)
    {
        _bankAccountService = bankAccountService;
        _mapper = mapper;
    }

    [HttpGet("{id:guid}", Name = "GetBankAccountAsync")]
    [ProducesResponseType(typeof(BankAccountResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
    public async Task<IResult> GetBankAccountAsync(Guid id, CancellationToken cancellationToken)
    {
        var account = await _bankAccountService.GetAsync(UserId, id, cancellationToken);
        var response = _mapper.Map<BankAccountResponse>(account);
        return Results.Ok(response);
    }

    [HttpGet]
    public async Task<IResult> GetBankAccountsAsync(CancellationToken cancellationToken)
    {
        var accounts = await _bankAccountService.GetAllAsync(UserId, cancellationToken);
        var response = _mapper.Map<ICollection<BankAccountResponse>>(accounts);
        return Results.Ok(response);
    }

    [HttpPost]
    public async Task<IResult> CreateBankAccountAsync(CreateBankAccountRequest request, CancellationToken cancellationToken)
    {
        var createDto = _mapper.Map<CreateBankAccountDto>(request);
        var createdBankAccount = await _bankAccountService.CreateAsync(UserId, createDto, cancellationToken);
        var response = _mapper.Map<BankAccountResponse>(createdBankAccount);
        return Results.CreatedAtRoute("GetBankAccountAsync", new { response.Id }, response);
    }
}
