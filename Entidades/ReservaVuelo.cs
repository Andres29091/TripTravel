using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TripTravel.Entidades
{
  public class ReservaVuelo
  {
    public int Id { get; set; }
    [Required]
    public int CodigoTurista { get; set; }
    [Required]
    public int NumeroVuelo { get; set; }
    [StringLength(50)]
    public string Clase { get; set; }
    public Vuelo Vuelo { get; set; }
  }
}
