using System.ComponentModel.DataAnnotations;

namespace TripTravel.Entidades
{
  public class ReservaHotel
  {
    public int Id { get; set; }
    [Required]
    public int CodigoTurista { get; set; }
    [Required]
    public int CodigoHotel { get; set; }
    public string Regimen { get; set; }
    public DateTime FechaLlegada { get; set; }
    public DateTime FechaPartida { get; set; }
  }
}
