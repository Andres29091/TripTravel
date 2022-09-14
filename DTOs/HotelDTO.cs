using System.ComponentModel.DataAnnotations;

namespace TripTravel.DTOs
{
  public class HotelDTO
  {
    public int Id { get; set; }
    [Required]
    public int Codigo { get; set; }
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Ciudad { get; set; }
    public string Telefono { get; set; }
    public string NumeroPlazas { get; set; }
  }
}
