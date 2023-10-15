using Microsoft.AspNetCore.Mvc;

using Flow.Api.Contracts.Requests.AccountOperation;

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

    [HttpGet("{id:guid}", Name = "GetAccountOperationAsync")]
    public async Task<IResult> GetAccountOperationAsync(Guid id, CancellationToken cancellationToken)
    {
        var dto = await _accountOperationsService.GetAsync(UserId, id, cancellationToken);
        return Results.Ok(_mapper.Map(dto));
    }

    [HttpPost]
    public async Task<IResult> CreateAccountOperationAsync(CreateAccountOperationRequest request, CancellationToken cancellationToken)
    {
        var createDto = _mapper.Map(request);
        var dto = await _accountOperationsService.CreateAsync(UserId, createDto, cancellationToken);
        var response = _mapper.Map(dto);

        return Results.CreatedAtRoute("GetAccountOperationAsync", new { response.Id }, response);
    }
}
