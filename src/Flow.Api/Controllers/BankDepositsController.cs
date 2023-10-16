using Microsoft.AspNetCore.Mvc;

using Flow.Api.Contracts.Requests.BankDeposit;
using Flow.Api.Contracts.Responses.BankDeposit;

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

    /// <summary>
    /// Get user bank deposit
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET: api/bankDeposits/e594b408-319b-482c-9bd3-689d71cb94ca
    /// </remarks>
    /// <param name="id">The Id of the bank deposit</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The user bank deposit</returns>
    [HttpGet("{id:guid}", Name = "GetBankDepositAsync")]
    [ProducesResponseType(typeof(BankDepositResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status404NotFound)]
    public async Task<IResult> GetBankDepositAsync(Guid id, CancellationToken cancellationToken)
    {
        var deposit = await _bankDepositService.GetAsync(UserId, id, cancellationToken);
        return Results.Ok(_mapper.Map(deposit));
    }

    /// <summary>
    /// Get the list of user bank deposits
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET: api/bankDeposits
    /// </remarks>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The list of user bank deposits</returns>
    [HttpGet]
    [ProducesResponseType(typeof(ICollection<BankDepositResponse>), StatusCodes.Status200OK)]
    public async Task<IResult> GetBankDepositsAsync(CancellationToken cancellationToken)
    {
        var deposits = await _bankDepositService.GetAllAsync(UserId, cancellationToken);
        return Results.Ok(_mapper.Map(deposits));
    }

    /// <summary>
    /// Create user bank deposit
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST: api/bankDeposits
    ///     {
    ///         "amount": 1200,
    ///         "currencyId": "ff11ff3e-01e3-435c-9e4f-47ecf06778b4",
    ///         "rate": 6.2,
    ///         "type": 1,
    ///         "periodInMonthes": 13,
    ///         "refundAccountId": "751bd4bb-437c-44d4-a344-2625cd3921ff"
    ///      }
    /// </remarks>
    /// <param name="request">The create bank deposit request</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The newly create user bank deposit</returns>
    [HttpPost]
    [ProducesResponseType(typeof(BankDepositResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
    public async Task<IResult> CreateBankDepositAsync(CreateBankDepositRequest request, CancellationToken cancellationToken)
    {
        var createDepositDto = _mapper.Map(request);
        var createdDeposit = await _bankDepositService.CreateAsync(UserId, createDepositDto, cancellationToken);
        var response = _mapper.Map(createdDeposit);
        return Results.CreatedAtRoute("GetBankDepositAsync", new { response.Id }, response);
    }
}
