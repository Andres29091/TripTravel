using System.ComponentModel.DataAnnotations;

namespace TripTravel.Entidades
{
  public class Turista
  {
    public int Id { get; set; }
    [Required]
    public int Codigo { get; set; }
    public string Nombres { get; set; }
    public string Apellidos { get; set; }
    public string Direccion { get; set; }
    public string telefono { get; set; }
  }
}
