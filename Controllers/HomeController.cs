using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/home")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { mensaje = "La API está funcionando 🚀" });
    }
}
