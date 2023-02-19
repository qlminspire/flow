using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using Flow.Api.Models.Bank;
using Flow.Business.Models.Bank;
using Flow.Business.Services;

namespace Flow.Api.Controllers.Static;

public class BanksController : BaseController
{
    private readonly IBankService _bankService;
    private readonly IMapper _mapper;

    public BanksController(IBankService bankService, IMapper mapper)
    {
        _bankService = bankService;
        _mapper = mapper;
    }

    [HttpGet("{id:guid}", Name = "GetBankAsync")]
    public async Task<BankResponse> GetBankAsync(Guid id, CancellationToken cancellationToken)
    {
        var bank = await _bankService.GetAsync(id, cancellationToken);
        var bankResponse = _mapper.Map<BankResponse>(bank);
        return bankResponse;
    }

    [HttpGet]
    public async Task<ICollection<BankResponse>> GetBanksAsync(CancellationToken cancellationToken)
    {
        var banks = await _bankService.GetAsync(cancellationToken);
        return _mapper.Map<ICollection<BankResponse>>(banks);
    }

    [HttpPost]
    public async Task<IResult> CreateBankAsync([FromBody] CreateBankRequest request, CancellationToken cancellationToken)
    {
        var dto = _mapper.Map<CreateBankDto>(request);
        var createdBank = await _bankService.CreateAsync(dto, cancellationToken);
        var response = _mapper.Map<BankResponse>(createdBank);
        return Results.CreatedAtRoute("GetBankAsync", new { response.Id }, response);
    }

    [HttpPut("{id:guid}")]
    public async Task<IResult> UpdateBankAsync(Guid id, [FromBody] UpdateBankRequest request, CancellationToken cancellationToken)
    {
        var dto = _mapper.Map<UpdateBankDto>(request);
        await _bankService.UpdateAsync(id, dto, cancellationToken);
        return Results.Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IResult> DeleteBankAsync(Guid id, CancellationToken cancellationToken)
    {
        await _bankService.DeleteAsync(id, cancellationToken);
        return Results.Ok();
    }
}
