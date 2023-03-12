using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using Flow.Api.Models.BankAccount;
using Flow.Business.Models.BankAccount;
using Flow.Business.Services;

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
