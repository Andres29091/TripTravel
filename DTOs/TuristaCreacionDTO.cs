using System.ComponentModel.DataAnnotations;

namespace TripTravel.DTOs
{
  public class TuristaCreacionDTO
  {
    public int Id { get; set; }
    [Required]
    public int Codigo { get; set; }
    [StringLength(60)]
    public string Nombres { get; set; }
    public string Apellidos { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public IFormFile Foto { get; set; }
  }
}
