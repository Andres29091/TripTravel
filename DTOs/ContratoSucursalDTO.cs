using System.ComponentModel.DataAnnotations;
using TripTravel.Entidades;

namespace TripTravel.DTOs
{
  public class ContratoSucursalDTO
  {
    public int Id { get; set; }
    [Required]
    public int CodigoTurista { get; set; }
    [Required]
    public int CodigoSucursal { get; set; }
    public Turista Turista { get; set; }
    public Sucursal Sucursal { get; set; }
  }
}
