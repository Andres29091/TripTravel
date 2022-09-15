using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TripTravel.Entidades
{
  public class Sucursal
  {
    public int Id { get; set; }
    public int CodigoSucursal { get; set; }
    [StringLength(100)]
    public string Direccion { get; set; }
    [StringLength(100)]
    public string Telefono { get; set; }
    public List<ContratoSucursal> ContratoSucursal { get; set; }
  }
}
