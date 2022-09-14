using System.ComponentModel.DataAnnotations;

namespace TripTravel.DTOs
{
  public class ContratoSucursalCreacionDTO
  {
    public int Id { get; set; }
    [Required]
    public int CodigoTurista { get; set; }
    [Required]
    public int CodigoSucursal { get; set; }
  }
}
