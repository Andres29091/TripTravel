using System.ComponentModel.DataAnnotations;

namespace TripTravel.Entidades
{
  public class Sucursal
  {
    public int Id { get; set; }
    [Required]
    public int Codigo { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
  }
}
