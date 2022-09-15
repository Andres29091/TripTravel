using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripTravel.Data;
using TripTravel.DTOs;
using TripTravel.Entidades;

namespace TripTravel.Controllers
{

  [ApiController]
  [Route("api/vuelo")]
  public class VueloController : Controller
  {
    private readonly ILogger<VueloController> logger;
    private readonly ApplicationDbContext context;
    private readonly IMapper mapper;


    //hereda de ApplicationDbContext que esta en la carpeta Data

    //llamamos los private creados lineas arriba
    public VueloController(ILogger<VueloController> logger, ApplicationDbContext context, IMapper mapper)
    {
      this.logger = logger;
      this.context = context;
      this.mapper = mapper;
    }


    // este metodo es como si hicieramos un select*from a la tabla genero
    [HttpGet("[action]")]
    //creamos una tarea asyncrona
    public async Task<ActionResult<List<Vuelo>>> ObtenerVuelo()
    {
      //se hace directo con el contexto de la tabla
      return await context.Vuelo.ToListAsync();

    }

    //utilizaremos esta ves con DTO, Busqueda por parametro Id
    [HttpGet("[action]/{id:int}")]
    public async Task<ActionResult<VueloDTO>> ObtenerVueloPorId(int id)
    {

      var vuelo = await context.Vuelo.FirstOrDefaultAsync(x => x.Id == id);

      if (vuelo == null)
      {
        return NotFound();
      }
      return mapper.Map<VueloDTO>(vuelo);

    }


    //Crear
    [HttpPost("[action]")]

    public async Task<ActionResult> CrearVuelo([FromBody] VueloCreacionDTO vueloCreacionDTO)

    {

      var vuelo = mapper.Map<Vuelo>(vueloCreacionDTO);
      context.Add(vuelo);
      await context.SaveChangesAsync();
      return NoContent();//codigo 204 hace la tarea pero no muestra ningun resultado

    }


    //Actualizar
    [HttpPut("[action]/{id:int}")] //le mandamos id como parametro

    public async Task<ActionResult> ActualizarVuelo(Vuelo vuelo, int id)

    {
      if (vuelo.Id != id)
      {

        return BadRequest("El registro no existe");

      }

      var existe = await context.Vuelo.AnyAsync(x => x.Id == id);

      if (!existe)
      {
        return NotFound();
      }

      context.Update(vuelo);
      await context.SaveChangesAsync();
      return Ok(); //codigo 200  que esta ok

    }

    //Eliminar-Delete
    [HttpDelete("[action]/{id:int}")] //le mandamos id como parametro

    public async Task<ActionResult> EliminarVuelo(int id)

    {

      var vuelo = await context.Vuelo.FirstOrDefaultAsync(x => x.Id == id);

      if (vuelo == null)
      {
        return NotFound();
      }

      context.Remove(vuelo);
      await context.SaveChangesAsync();
      return NoContent(); //codigo 204 con el NoContent el no muestra ningun tipo de respuesta o mensaje

    }


  }
}

