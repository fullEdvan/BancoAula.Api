namespace BancoAula.Api.Models;
using System.ComponentModel.DataAnnotations;

public class Conta
{
  public int Id { get; set; }
  public int ClienteId { get; set; }

   [Range(1000, 999999)]
  public int Numero { get; set; }

     [Required]
  public string Tipo { get; set; } = "Corrente";

  [Range(0, 1000000)]
  public decimal Saldo { get; set; }
  public bool Ativa { get; set; } = true;
}