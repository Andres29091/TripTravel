using AutoMapper;
using TripTravel.Data;
using TripTravel.DTOs;
using TripTravel.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TripTravel.Controllers
{

    [ApiController]

    [Route("api/Vuelo")]


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
        [HttpGet]
        //creamos una tarea asyncrona
        public async Task<ActionResult<List<Vuelo>>> Get()
        {
            //se hace directo con el contexto de la tabla
            return await context.Vuelo.ToListAsync();

        }

        //utilizaremos esta ves con DTO, Busqueda por parametro Id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<VueloDTO>> Get(int id)
        {

            var vuelo = await context.Vuelo.FirstOrDefaultAsync(x => x.Id == id);

            if (vuelo == null)
            {
                return NotFound();
            }
            return mapper.Map<VueloDTO>(vuelo);

        }


        //Crear
        [HttpPost]

        public async Task<ActionResult> Post([FromBody] VueloCreacionDTO vueloCreacionDTO)

        {

            var vuelo = mapper.Map<ReservaVuelo>(vueloCreacionDTO);
            context.Add(vuelo);
            await context.SaveChangesAsync();
            return NoContent();//codigo 204 hace la tarea pero no muestra ningun resultado

        }


        //Actualizar
        [HttpPut("{id}")] //le mandamos id como parametro

        public async Task<ActionResult> Put(Vuelo vuelo, int id)

        {
            if (vuelo.Id != id)
            {

                return BadRequest("El vuelo no existe");

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
        [HttpDelete("{id}")] //le mandamos id como parametro

        public async Task<ActionResult> Delete(int id)

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

