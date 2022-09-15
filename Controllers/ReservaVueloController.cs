using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripTravel.Data;
using TripTravel.DTOs;
using TripTravel.Entidades;

namespace TripTravel.Controllers
{
  [ApiController]
  [Route("api/reservavuelos")]
  public class ReservaVueloController : Controller
  {
    private readonly ILogger<ReservaVueloController> logger;
    private readonly ApplicationDbContext context;
    private readonly IMapper mapper;


    //hereda de ApplicationDbContext que esta en la carpeta Data

    //llamamos los private creados lineas arriba
    public ReservaVueloController(ILogger<ReservaVueloController> logger, ApplicationDbContext context, IMapper mapper)
    {
      this.logger = logger;
      this.context = context;
      this.mapper = mapper;
    }

    // este metodo es como si hicieramos un select*from a la tabla genero
    [HttpGet("[action]")]
    //creamos una tarea asyncrona
    public async Task<ActionResult<List<ReservaVuelo>>> ObtenerReservaVuelo()
    {
      //se hace directo con el contexto de la tabla
      return await context.ReservaVuelo.ToListAsync();

    }

    //utilizaremos esta ves con DTO, Busqueda por parametro Id
    [HttpGet("[action]{id:int}")]
    public async Task<ActionResult<ReservaVueloDTO>> ObtenerReservaVueloPorId(int id)
    {
      var reservavuelo = await context.ReservaVuelo.FirstOrDefaultAsync(x => x.Id == id);

      if (reservavuelo == null)
      {
        return NotFound();
      }
      return mapper.Map<ReservaVueloDTO>(reservavuelo);
    }

    //Crear
    [HttpPost("[action]")]
    public async Task<ActionResult> CrearReservaVuelo([FromBody] ReservaVueloCreacionDTO reservavueloCreacionDTO)
    {
      var reservavuelo = mapper.Map<ReservaVuelo>(reservavueloCreacionDTO);
      context.Add(reservavuelo);
      await context.SaveChangesAsync();
      return NoContent();//codigo 204 hace la tarea pero no muestra ningun resultado

    }

    //Actualizar
    [HttpPut("[action]/{id:int}")] //le mandamos id como parametro

    public async Task<ActionResult> ActualizarReservaVuelo(ReservaVuelo reservavuelo, int id)

    {
      if (reservavuelo.Id != id)
      {

        return BadRequest("La registro no existe");

      }

      var existe = await context.ReservaVuelo.AnyAsync(x => x.Id == id);

      if (!existe)
      {
        return NotFound();
      }

      context.Update(reservavuelo);
      await context.SaveChangesAsync();
      return Ok(); //codigo 200  que esta ok

    }

    //Eliminar-Delete
    [HttpDelete("[action]/{id:int}")] //le mandamos id como parametro

    public async Task<ActionResult> EliminarReservaVuelo(int id)

    {

      var reservavuelo = await context.ReservaVuelo.FirstOrDefaultAsync(x => x.Id == id);

      if (reservavuelo == null)
      {
        return NotFound();
      }

      context.Remove(reservavuelo);
      await context.SaveChangesAsync();
      return NoContent(); //codigo 204 con el NoContent el no muestra ningun tipo de respuesta o mensaje

    }
  }
}
