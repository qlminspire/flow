using Flow.Contracts.Requests.BankAccount;
using Flow.Contracts.Responses.BankAccount;
using Microsoft.AspNetCore.Mvc;

namespace Flow.Api.Controllers;

public class BankAccountsController : BaseController
{
    private readonly IBankAccountService _bankAccountService;
    private readonly BankAccountMapper _mapper;

    public BankAccountsController(IBankAccountService bankAccountService)
    {
        _bankAccountService = bankAccountService;
        _mapper = new BankAccountMapper();
    }

    /// <summary>
    /// Get user bank account
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET: api/bankAccounts/751bd4bb-437c-44d4-a344-2625cd3921ff
    /// </remarks>
    /// <param name="id">The bank account id</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The user bank account</returns>
    [HttpGet("{id:guid}", Name = "GetBankAccountAsync")]
    [ProducesResponseType(typeof(BankAccountResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status404NotFound)]
    public async Task<IResult> GetBankAccountAsync(Guid id, CancellationToken cancellationToken)
    {
        var dto = await _bankAccountService.GetForUserAsync(UserId, id, cancellationToken);
        var response = _mapper.Map(dto);
        return Results.Ok(response);
    }

    /// <summary>
    /// Get the list of user bank accounts
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET: api/bankAccounts
    /// </remarks>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The list of user bank accounts</returns>
    [HttpGet]
    [ProducesResponseType(typeof(ICollection<BankAccountResponse>), StatusCodes.Status200OK)]
    public async Task<IResult> GetBankAccountsAsync(CancellationToken cancellationToken)
    {
        var accounts = await _bankAccountService.GetAllForUserAsync(UserId, cancellationToken);
        var response = _mapper.Map(accounts);
        return Results.Ok(response);
    }

    /// <summary>
    /// Create user bank account
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST: api/bankAccounts
    ///     {
    ///         "name": "Жилье",
    ///         "iban": "78931212",
    ///         "bankId": "8e7dc274-fa0c-430f-b6f0-f629259b734b",
    ///         "amount": "500",
    ///         "currency": "BYN"
    ///     }
    /// </remarks>
    /// <param name="request">The bank account create request</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The newly created user bank account</returns>
    [HttpPost]
    [ProducesResponseType(typeof(BankAccountResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
    public async Task<IResult> CreateBankAccountAsync(CreateBankAccountRequest request,
        CancellationToken cancellationToken)
    {
        var createDto = _mapper.Map(request);

        var dto = await _bankAccountService.CreateAsync(UserId, createDto, cancellationToken);

        var response = _mapper.Map(dto);
        return Results.CreatedAtRoute("GetBankAccountAsync", new { response.Id }, response);
    }
}