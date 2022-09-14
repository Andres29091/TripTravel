namespace TripTravel.Entidades
{
  public class Vuelo
  {
    public int Id { get; set; }
    public int Numero { get; set; }
    public DateOnly Fecha { get; set; }
    public string Hora { get; set; }
    public string Origen { get; set; }
    public string Destino { get; set; }
    public string PlazaToral { get; set; }
    public string PlazaTurista { get; set; }
  }
}
