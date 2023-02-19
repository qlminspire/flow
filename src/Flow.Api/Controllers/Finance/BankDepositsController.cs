using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using Flow.Api.Models.BankDeposit;
using Flow.Business.Models.BankDeposit;
using Flow.Business.Services;

namespace Flow.Api.Controllers.Finance;

public sealed class BankDepositsController : BaseController
{
    private readonly IBankDepositService _bankDepositService;
    private readonly IMapper _mapper;

    public BankDepositsController(IBankDepositService bankDepositService, IMapper mapper)
    {
        _bankDepositService = bankDepositService;
        _mapper = mapper;
    }

    [HttpGet("{id:guid}", Name = "GetBankDepositAsync")]
    public async Task<IResult> GetBankDepositAsync(Guid id, CancellationToken cancellationToken)
    {
        var deposit = await _bankDepositService.GetAsync(UserId, id, cancellationToken);
        var response = _mapper.Map<BankDepositResponse>(deposit);
        return Results.Ok(response);
    }

    [HttpGet]
    public async Task<IResult> GetBankDepositsAsync(CancellationToken cancellationToken)
    {
        var deposits = await _bankDepositService.GetAllAsync(UserId, cancellationToken);
        var response = _mapper.Map<ICollection<BankDepositResponse>>(deposits);
        return Results.Ok(response);
    }

    [HttpPost]
    public async Task<IResult> CreateBankDepositAsync(CreateBankDepositRequest request, CancellationToken cancellationToken)
    {
        var createDepositDto = _mapper.Map<CreateBankDepositDto>(request);
        var createdDeposit = await _bankDepositService.CreateAsync(UserId, createDepositDto, cancellationToken);
        var response = _mapper.Map<BankDepositResponse>(createdDeposit);
        return Results.CreatedAtRoute("GetBankDepositAsync", new { response.Id }, response);
    }
}
