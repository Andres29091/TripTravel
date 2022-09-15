using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripTravel.Data;
using TripTravel.DTOs;
using TripTravel.Entidades;

namespace TripTravel.Controllers
{

  [ApiController]
  [Route("api/sucursal")]
  public class SucursalController : Controller
  {
    private readonly ILogger<SucursalController> logger;
    private readonly ApplicationDbContext context;
    private readonly IMapper mapper;


    //hereda de ApplicationDbContext que esta en la carpeta Data

    //llamamos los private creados lineas arriba
    public SucursalController(ILogger<SucursalController> logger, ApplicationDbContext context, IMapper mapper)
    {
      this.logger = logger;
      this.context = context;
      this.mapper = mapper;
    }


    // este metodo es como si hicieramos un select*from a la tabla genero
    [HttpGet("[action]")]
    //creamos una tarea asyncrona
    public async Task<ActionResult<List<Sucursal>>> ObtenerSucursal()
    {
      //se hace directo con el contexto de la tabla
      return await context.Sucursal.ToListAsync();

    }

    //utilizaremos esta ves con DTO, Busqueda por parametro Id
    [HttpGet("[action]/{id:int}")]
    public async Task<ActionResult<SucursalDTO>> ObtenerSucursalPorId(int id)
    {

      var vuelo = await context.Sucursal.FirstOrDefaultAsync(x => x.Id == id);

      if (vuelo == null)
      {
        return NotFound();
      }
      return mapper.Map<SucursalDTO>(vuelo);

    }


    //Crear
    [HttpPost("[action]")]

    public async Task<ActionResult> CrearSucursal([FromBody] SucursalCreacionDTO sucursalCreacionDTO)
    {
      var sucursal = mapper.Map<Sucursal>(sucursalCreacionDTO);
      context.Add(sucursal);
      await context.SaveChangesAsync();
      return NoContent();//codigo 204 hace la tarea pero no muestra ningun resultado
    }

    //Actualizar
    [HttpPut("[action]/{id:int}")] //le mandamos id como parametro

    public async Task<ActionResult> ActualizarSucursal(Sucursal sucursal, int id)

    {
      if (sucursal.Id != id)
      {

        return BadRequest("La registro no existe");

      }

      var existe = await context.Sucursal.AnyAsync(x => x.Id == id);

      if (!existe)
      {
        return NotFound();
      }

      context.Update(sucursal);
      await context.SaveChangesAsync();
      return Ok(); //codigo 200  que esta ok

    }

    //Eliminar-Delete
    [HttpDelete("[action]/{id:int}")] //le mandamos id como parametro

    public async Task<ActionResult> EliminarSucursal(int id)
    {
      var sucursal = await context.Sucursal.FirstOrDefaultAsync(x => x.Id == id);

      if (sucursal == null)
      {
        return NotFound();
      }

      context.Remove(sucursal);
      await context.SaveChangesAsync();
      return NoContent(); //codigo 204 con el NoContent el no muestra ningun tipo de respuesta o mensaje

    }


  }
}

