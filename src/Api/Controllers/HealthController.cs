using Microsoft.AspNetCore.Mvc;

namespace ScalableRestApi.Api.Controllers;

[ApiController]
[Route("api/[Controller]")]

public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            message = "API is running",
            age = "I am just born now"
        });
    }
}