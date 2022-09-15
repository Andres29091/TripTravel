using System.ComponentModel.DataAnnotations;
using TripTravel.Entidades;

namespace TripTravel.DTOs
{
  public class TuristaCreacionDTO
  {
    [Required]
    public int CodigoTurista { get; set; }
    [StringLength(60)]
    public string Nombres { get; set; }
    [StringLength(60)]
    public string Apellidos { get; set; }
    [StringLength(100)]
    public string Direccion { get; set; }
    [StringLength(50)]
    public string Telefono { get; set; }
    public IFormFile Foto { get; set; }
  }
}

