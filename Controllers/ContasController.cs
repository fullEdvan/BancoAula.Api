using Microsoft.AspNetCore.Mvc;

namespace BancoAula.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContasController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("API do BancoAula no ar");
    }
}