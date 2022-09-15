using System.ComponentModel.DataAnnotations;

namespace TripTravel.Entidades
{
  public class Vuelo
  {
    public int Id { get; set; }
    public int NumeroVuelo { get; set; }
    public DateTime Fecha { get; set; }
    [StringLength(30)]
    public string Hora { get; set; }
    [StringLength(50)]
    public string Origen { get; set; }
    [StringLength(50)]
    public string Destino { get; set; }
    [StringLength(50)]
    public string PlazaTotal { get; set; }
    [StringLength(30)]
    public string PlazaTurista { get; set; }
    public List<ReservaVuelo> ReservaVuelo { get; set; }
  }
}
