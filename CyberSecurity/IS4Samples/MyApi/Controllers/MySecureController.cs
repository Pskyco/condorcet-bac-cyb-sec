using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyApi.Controllers;

[Route("mySecure")]
[Authorize]
public class MySecureController : ControllerBase
{
    [HttpGet]
    public IActionResult GetMySecure()
    {
        return new JsonResult(User.Claims.Select(z => new { z.Type, z.Value }));
    }
}