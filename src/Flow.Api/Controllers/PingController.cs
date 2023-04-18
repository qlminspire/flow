using Microsoft.AspNetCore.Mvc;

namespace Flow.Api.Controllers;

public class PingController : BaseController
{
    /// <summary>
    /// The simplest API accessibility check
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET: api/ping
    /// </remarks>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IResult Ping()
    {
        return Results.Ok();
    }
}
