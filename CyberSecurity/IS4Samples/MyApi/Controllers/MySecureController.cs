using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyApi.Controllers;

[Route("mySecure")]
public class MySecureController : ControllerBase
{
    [HttpGet]
    [Authorize]
    public IActionResult GetMySecure()
    {
        return new JsonResult(User.Claims.Select(z => new { z.Type, z.Value }));
    }
}