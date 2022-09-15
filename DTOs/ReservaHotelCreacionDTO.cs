using System.ComponentModel.DataAnnotations;
using TripTravel.Entidades;

namespace TripTravel.DTOs
{
  public class ReservaHotelCreacionDTO
  {
    [Required]
    public int CodigoTurista { get; set; }
    [Required]
    public int CodigoHotel { get; set; }
    [StringLength(100)]
    public string Regimen { get; set; }
    public DateTime FechaLlegada { get; set; }
    public DateTime FechaPartida { get; set; }
  }
}
