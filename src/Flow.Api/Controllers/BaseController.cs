using Microsoft.AspNetCore.Mvc;

namespace Flow.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Produces(ApiConstants.ContentType.ApplicationJson)]
public abstract class BaseController : ControllerBase
{
    public Guid UserId => new("fc8129ce-2ffa-4c99-b6ab-8f525ef8653f");
}