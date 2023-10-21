using Flow.Contracts.Requests.Bank;
using Flow.Contracts.Responses.Bank;
using Microsoft.AspNetCore.Mvc;

namespace Flow.Api.Controllers;

public class BanksController : BaseController
{
    private readonly IBankService _bankService;
    private readonly ILogger<BanksController> _logger;

    private readonly BankMapper _mapper;

    public BanksController(IBankService bankService, ILogger<BanksController> logger)
    {
        _bankService = bankService;
        _logger = logger;

        _mapper = new();
    }

    /// <summary>
    /// Get bank
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
        var bank = await _bankService.GetAsync(id, cancellationToken);
        return Results.Ok(_mapper.Map(bank));
    }

    /// <summary>
    /// Get all banks
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
        _logger.LogInformation("The total banks amount is {@amount}. Banks: {@banks}", banks.Count, banks);
        return Results.Ok(_mapper.Map(banks));
    }

    /// <summary>
    /// Create bank
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
        var dto = _mapper.Map(request);

        var bank = await _bankService.CreateAsync(dto, cancellationToken);

        var response = _mapper.Map(bank);
        return Results.CreatedAtRoute("GetBankAsync", new { response.Id }, response);
    }

    /// <summary>
    /// Update bank
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     PUT: api/banks/ff11ff3e-01e3-435c-9e4f-47ecf06778b4
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
        var dto = _mapper.Map(request);
        await _bankService.UpdateAsync(id, dto, cancellationToken);
        return Results.NoContent();
    }

    /// <summary>
    /// Delete bank
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
        await _bankService.DeleteAsync(id, cancellationToken);
        return Results.NoContent();
    }
}
