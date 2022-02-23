using System.Net.Http.Headers;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace MyMvc.Controllers;

public class MyApiController : Controller
{
    private readonly ILogger<MyApiController> _logger;

    public MyApiController(ILogger<MyApiController> logger)
    {
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var accessToken = await HttpContext.GetTokenAsync("access_token");

        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        //httpClient.SetBearerToken(accessToken);

        var content = await httpClient.GetStringAsync("https://localhost:6001/mySecure");

        return View(JsonArray.Parse(content));
    }
}
