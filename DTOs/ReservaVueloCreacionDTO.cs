using System.ComponentModel.DataAnnotations;
using TripTravel.Entidades;

namespace TripTravel.DTOs
{
  public class ReservaVueloCreacionDTO
  {
    [Required]
    public int CodigoTurista { get; set; }
    [Required]
    public int NumeroVuelo { get; set; }
    [StringLength(50)]
    public string Clase { get; set; }
  }
}
