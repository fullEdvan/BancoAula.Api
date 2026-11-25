namespace BancoAula.Api.Models;

public class Conta
{
  public int Id { get; set; }
  public int ClienteId { get; set; }
  public int Numero { get; set; }
  public string Tipo { get; set; } = "Corrente";
  public decimal Saldo { get; set; }
  public bool Ativa { get; set; } = true;
}