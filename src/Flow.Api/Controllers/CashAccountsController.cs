﻿using Microsoft.AspNetCore.Mvc;

using Flow.Api.Contracts.Requests.CashAccount;
using Flow.Api.Contracts.Responses.CashAccount;

namespace Flow.Api.Controllers;

public class CashAccountsController : BaseController
{
    private readonly ICashAccountService _cashAccountService;
    private readonly CashAccountMapper _mapper;

    public CashAccountsController(ICashAccountService cashAccountService)
    {
        _cashAccountService = cashAccountService;
        _mapper = new();
    }

    /// <summary>
    /// Get user cash account
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET api/cashAccounts/8e7dc274-fa0c-430f-b6f0-f629259b734b
    /// </remarks>
    /// <param name="id">The Id of cash account</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The user cash account</returns>
    [HttpGet("{id:guid}", Name = "GetCashAccountAsync")]
    [ProducesResponseType(typeof(CashAccountResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status404NotFound)]
    public async Task<IResult> GetCashAccountAsync(Guid id, CancellationToken cancellationToken)
    {
        var account = await _cashAccountService.GetAsync(UserId, id, cancellationToken);
        return Results.Ok(_mapper.Map(account));
    }


    /// <summary>
    /// Get list of user cash accounts
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET: api/cashAccounts
    /// </remarks>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The list of user cash accounts</returns>
    [HttpGet]
    [ProducesResponseType(typeof(ICollection<CashAccountResponse>), StatusCodes.Status200OK)]
    public async Task<IResult> GetCashAccountsAsync(CancellationToken cancellationToken)
    {
        var accounts = await _cashAccountService.GetAllAsync(UserId, cancellationToken);
        return Results.Ok(_mapper.Map(accounts));
    }

    /// <summary>
    /// Create user cash account
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST: api/cashAccounts
    ///     {
    ///         "name": "Жилье",
    ///         "amount": "200",
    ///         "currencyId": "076ea5ea-92dc-4e73-bcb9-cf5dac5ff165",
    ///     }
    /// </remarks>
    /// <param name="request">The create cash account request</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The newly created cash account</returns>
    [HttpPost]
    [ProducesResponseType(typeof(CashAccountResponse), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status404NotFound)]
    public async Task<IResult> CreateCashAccountAsync(CreateCashAccountRequest request, CancellationToken cancellationToken)
    {
        var createCashAccountDto = _mapper.Map(request);

        var createdCashAccount = await _cashAccountService.CreateAsync(UserId, createCashAccountDto, cancellationToken);
        var response = _mapper.Map(createdCashAccount);

        return Results.CreatedAtRoute("GetCashAccountAsync", new { response.Id }, response);
    }
}
