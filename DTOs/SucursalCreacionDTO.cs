using System.ComponentModel.DataAnnotations;
using TripTravel.Entidades;

namespace TripTravel.DTOs
{
  public class SucursalCreacionDTO
  {
    public int CodigoSucursal { get; set; }
    [StringLength(100)]
    public string Direccion { get; set; }
    [StringLength(100)]
    public string Telefono { get; set; }
  }
}
