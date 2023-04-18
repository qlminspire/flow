using Microsoft.AspNetCore.Mvc;

namespace Flow.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public abstract class BaseController : ControllerBase
{
    public Guid UserId => new("4563ee5c-6fbc-4270-a7bc-c6b5cb7d2bf8");
}
