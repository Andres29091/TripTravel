using Microsoft.EntityFrameworkCore;
using TripTravel.Entidades;

namespace TripTravel.Data
{
    public class ApplicationDbContext: DbContext
    {
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }

    //protected override void  OnModelCreating(ModelBuilder modelBuilder)
    //{

    //    modelBuilder.Entity<PeliculasGeneros>()
    //        .HasKey(x => new { x.GeneroId, x.PeliculaId });

    //}

    public DbSet<Turista> Turista { get; set; }
    public DbSet<Hotel> Hotel { get; set; }
    public DbSet<ContratoSucursal> ContratoSucursal { get; set; }
    public DbSet<ReservaHotel> ReservaHotel { get; set; }
    public DbSet<ReservaVuelo> ReservaVuelo { get; set; }
    public DbSet<Sucursal> Sucursal { get; set; }
    public DbSet<Vuelo> Vuelo { get; set; }

  }
}
