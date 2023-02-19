using Microsoft.AspNetCore.Mvc;

namespace Flow.Api.Controllers;

public class PingController : BaseController
{
    [HttpGet]
    public IResult Ping()
    {
        return Results.Ok();
    }
}
