using System.ComponentModel.DataAnnotations;
using TripTravel.Entidades;

namespace TripTravel.DTOs
{
  public class HotelDTO
  {
    public int Id { get; set; }
    [Required]
    public int CodigoHotel { get; set; }
    [StringLength(100)]
    public string Nombre { get; set; }
    [StringLength(100)]
    public string Direccion { get; set; }
    [StringLength(50)]
    public string Ciudad { get; set; }
    [StringLength(50)]
    public string Telefono { get; set; }
    public int NumeroPlazas { get; set; }
    public List<ReservaHotel> ReservaHotel { get; set; }
  }
}
