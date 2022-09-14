using System.ComponentModel.DataAnnotations;

namespace TripTravel.Entidades
{
  public class ContratoSucursal
  {
    public int Id { get; set; }
    [Required]
    public int CodigoTurista { get; set; }
    [Required]
    public int CodigoSucursal { get; set; }
  }
}
