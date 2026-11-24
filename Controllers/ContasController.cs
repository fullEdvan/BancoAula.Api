using Microsoft.AspNetCore.Mvc;

namespace BancoAula.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContasController : ControllerBase
{
  [HttpGet]
  public IActionResult Get()
  {
    var contas = new[]
    {
            new { Id = 1, Numero = 1001 },
            new { Id = 2, Numero = 1002 }
        };

    return Ok(contas);
  }
}