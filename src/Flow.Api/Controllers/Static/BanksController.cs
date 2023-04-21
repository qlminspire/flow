using AutoMapper;
using Flow.Api.Models;
using Flow.Api.Models.Bank;
using Flow.Application.Models.Bank;
using Flow.Application.Services;
using Microsoft.AspNetCore.Mvc;

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

    /// <summary>
    /// Gets bank
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET: api/banks/ff11ff3e-01e3-435c-9e4f-47ecf06778b4
    /// </remarks>
    /// <param name="id">The Id of the bank</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The bank</returns>
    [HttpGet("{id:guid}", Name = "GetBankAsync")]
    [ProducesResponseType(typeof(BankResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status404NotFound)]
    public async Task<IResult> GetBankAsync(Guid id, CancellationToken cancellationToken)
    {
        var result = await _bankService.GetAsync(id, cancellationToken);
        return result.Match(bank => Results.Ok(_mapper.Map<BankResponse>(bank)),
                               _ => Results.NotFound());
    }

    /// <summary>
    /// Gets all banks
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET: api/banks
    /// </remarks>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The list of banks</returns>
    [HttpGet]
    [ProducesResponseType(typeof(ICollection<BankResponse>), StatusCodes.Status200OK)]
    public async Task<IResult> GetBanksAsync(CancellationToken cancellationToken)
    {
        var banks = await _bankService.GetAsync(cancellationToken);
        var response = _mapper.Map<ICollection<BankResponse>>(banks);
        return Results.Ok(response);
    }

    /// <summary>
    /// Creates bank
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     POST: api/banks
    ///     {
    ///        "name": "Alphabank",
    ///        "isActive": true
    ///     }
    /// </remarks>
    /// <param name="request">The create bank request</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The newly created bank</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ICollection<BankResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status404NotFound)]
    public async Task<IResult> CreateBankAsync([FromBody] CreateBankRequest request, CancellationToken cancellationToken)
    {
        var dto = _mapper.Map<CreateBankDto>(request);
        var result = await _bankService.CreateAsync(dto, cancellationToken);
        return result.Match(bank =>
        {
            var response = _mapper.Map<BankResponse>(bank);
            return Results.CreatedAtRoute("GetBankAsync", new { response.Id }, response);
        }, validation => Results.BadRequest(validation.Message));
    }

    /// <summary>
    /// Updates bank
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     POST: api/banks/ff11ff3e-01e3-435c-9e4f-47ecf06778b4
    ///     {
    ///        "name": "Alphabank",
    ///        "isActive": false
    ///     }
    /// </remarks>
    /// <param name="id">The Id of the bank</param>
    /// <param name="request">The update bank request</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns></returns>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status404NotFound)]
    public async Task<IResult> UpdateBankAsync(Guid id, [FromBody] UpdateBankRequest request, CancellationToken cancellationToken)
    {
        var dto = _mapper.Map<UpdateBankDto>(request);
        var results = await _bankService.UpdateAsync(id, dto, cancellationToken);
        return results.Match(_ => Results.NoContent(),
                             _ => Results.NotFound(),
                             (validation) => Results.BadRequest(validation.Message));
    }

    /// <summary>
    /// Deletes bank
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     DELETE: api/banks/ff11ff3e-01e3-435c-9e4f-47ecf06778b4
    /// </remarks>
    /// <param name="id">The id of the bank</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns></returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status404NotFound)]
    public async Task<IResult> DeleteBankAsync(Guid id, CancellationToken cancellationToken)
    {
        var results = await _bankService.DeleteAsync(id, cancellationToken);
        return results.Match(_ => Results.NoContent(),
                             _ => Results.NotFound());
    }
}
