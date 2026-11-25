using Microsoft.AspNetCore.Mvc;
using BancoAula.Api.Models;

namespace BancoAula.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContasController : ControllerBase
{
  private static readonly List<Conta> _contas = new()
    {
        new Conta { Id = 1, ClienteId = 1, Numero = 1001,
                    Tipo = "Corrente", Saldo = 1500m },
        new Conta { Id = 2, ClienteId = 1, Numero = 1002,
                    Tipo = "Poupanca", Saldo = 5200m }
    };
  private static int _proximoId = 3;

  [HttpGet]
  public ActionResult<IEnumerable<Conta>> GetTodas()
  {
    return Ok(_contas);
  }

  [HttpGet("{id:int}")]
  public ActionResult<Conta> GetPorId(int id)
  {
    var conta = _contas.FirstOrDefault(c => c.Id == id);
    if (conta == null)
      return NotFound();

    return Ok(conta);
  }

  [HttpPost]
  public ActionResult<Conta> Criar(Conta novaConta)
  {
    novaConta.Id = _proximoId++;
    _contas.Add(novaConta);

    return CreatedAtAction(
        nameof(GetPorId), new { id = novaConta.Id }, novaConta);
  }
}