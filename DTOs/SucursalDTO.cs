using System.ComponentModel.DataAnnotations;
using TripTravel.Entidades;

namespace TripTravel.DTOs
{
  public class SucursalDTO
  {
    public int Id { get; set; }
    [Required]
    public int CodigoSucursal { get; set; }
    [StringLength(100)]
    public string Direccion { get; set; }
    [StringLength(100)]
    public string Telefono { get; set; }
    public List<ContratoSucursal> ContratoSucursal { get; set; }
  }
}
