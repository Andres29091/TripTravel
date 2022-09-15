using System.ComponentModel.DataAnnotations;
using TripTravel.Entidades;

namespace TripTravel.DTOs
{
  public class TuristaDTO
  {
    public int Id { get; set; }
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
    [StringLength(200)]
    public string Foto { get; set; }
    public List<ContratoSucursal> ContratoSucursal { get; set; }
    public List<ReservaHotel> ReservaHotel { get; set; }
    public List<ReservaVuelo> ReservaVuelo { get; set; }
  }
}
