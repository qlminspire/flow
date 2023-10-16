using Microsoft.AspNetCore.Mvc;

using Flow.Api.Contracts.Requests.AccountOperation;
using Flow.Api.Contracts.Responses.AccountOperation;

namespace Flow.Api.Controllers;

public class AccountOperationsController : BaseController
{
    private readonly IAccountOperationService _accountOperationsService;
    private readonly AccountOperationMapper _mapper;

    public AccountOperationsController(IAccountOperationService accountOperationsService)
    {
        _accountOperationsService = accountOperationsService;
        _mapper = new();
    }

    /// <summary>
    /// Get account operation
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET: api/accountOperations/ff11ff3e-01e3-435c-9e4f-47ecf06778b4
    /// </remarks>
    /// <param name="id">The Id of the account operation</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The account operation</returns>
    [HttpGet("{id:guid}", Name = "GetAccountOperationAsync")]
    [ProducesResponseType(typeof(AccountOperationResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status404NotFound)]
    public async Task<IResult> GetAccountOperationAsync(Guid id, CancellationToken cancellationToken)
    {
        var dto = await _accountOperationsService.GetAsync(UserId, id, cancellationToken);
        return Results.Ok(_mapper.Map(dto));
    }

    /// <summary>
    /// Create account operation
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     POST: api/accountOperations
    ///     {
    ///         "fromAccountId": "751bd4bb-437c-44d4-a344-2625cd3921ff",
    ///         "toAccountId": "e7513988-cb8a-4746-81d1-c4b1522f54f3",
    ///         "amount": 150
    ///     }
    /// </remarks>
    /// <param name="request">The create account operation request</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The newly created account operation</returns>
    [HttpPost]
    [ProducesResponseType(typeof(AccountOperationResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
    public async Task<IResult> CreateAccountOperationAsync(CreateAccountOperationRequest request, CancellationToken cancellationToken)
    {
        var createDto = _mapper.Map(request);
        var dto = await _accountOperationsService.CreateAsync(UserId, createDto, cancellationToken);
        var response = _mapper.Map(dto);

        return Results.CreatedAtRoute("GetAccountOperationAsync", new { response.Id }, response);
    }
}
