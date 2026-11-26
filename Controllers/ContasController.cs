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
  public ActionResult<List<Conta>> GetTodas([FromQuery] string? tipo)
  {
    if (string.IsNullOrEmpty(tipo))
      return Ok(_contas);

    var contasFiltradas = _contas
        .Where(c => c.Tipo.Equals(tipo, StringComparison.OrdinalIgnoreCase))
        .ToList();
    return Ok(contasFiltradas);
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

  [HttpPut("{id:int}")]
  public IActionResult Atualizar(int id, Conta dados)
  {
    var conta = _contas.FirstOrDefault(c => c.Id == id);
    if (conta == null)
      return NotFound();
    conta.Tipo = dados.Tipo;
    conta.Saldo = dados.Saldo;
    conta.Ativa = dados.Ativa;

    return NoContent();
  }

  [HttpDelete("{id:int}")]
  public IActionResult Remover(int id)
  {
    var conta = _contas.FirstOrDefault(c => c.Id == id);
    
    if (conta == null)
      return NotFound();

    _contas.Remove(conta);
    return NoContent();
  }
}