using System.ComponentModel.DataAnnotations;
using TripTravel.Entidades;

namespace TripTravel.DTOs
{
  public class ContratoSucursalCreacionDTO
  {
    [Required]
    public int CodigoTurista { get; set; }
    [Required]
    public int CodigoSucursal { get; set; }
  }
}
