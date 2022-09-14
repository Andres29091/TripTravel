using System.ComponentModel.DataAnnotations;

namespace TripTravel.DTOs
{
  public class ReservaVueloCreacionDTO
  {
    public int Id { get; set; }
    [Required]
    public int CodigoTurista { get; set; }
    [Required]
    public int NumeroVuelo { get; set; }
    public string Clase { get; set; }
  }
}
