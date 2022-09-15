using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NRWeb.Interfaces.Log;
using TripTravel.Data;
using TripTravel.DTOs;
using TripTravel.Entidades;
using TripTravel.Servicios;

namespace TripTravel.Controllers
{
  [ApiController]
  [Route("api/turista")]
  public class TuristaController : Controller
  {
    private readonly IMapper _mapper;
    private readonly IAlmacenadorArchivos _almacenadorArchivos;
    private readonly ApplicationDbContext _context;
    private readonly string _contenedor = "Files";
    private readonly ILogService _logService;

    public TuristaController(IMapper mapper, IAlmacenadorArchivos almacenadorArchivos, ApplicationDbContext context, ILogService logService)
    {
      this._mapper = mapper;
      this._almacenadorArchivos = almacenadorArchivos;
      this._context = context;
      this._logService = logService;
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<List<TuristaDTO>>> ObtenerTurista()
    {
      try
      {
        return _mapper.Map<List<TuristaDTO>>(await _context.Turista.ToListAsync());
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("GetTurist", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpGet("[action]/{id:int}")]
    public async Task<ActionResult<TuristaDTO>> ObtenerTuristaPorId([FromRoute] int id)
    {
      try
      {
        var turista = await _context.Turista.FirstOrDefaultAsync(x => x.Id == id);
        if (turista == null)
        {
          return NotFound();
        }
        return _mapper.Map<TuristaDTO>(turista);
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("GetTuristFromId", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpPost("[action]")]
    public async Task<ActionResult> CrearTurista([FromForm] TuristaCreacionDTO turistaCreacionDTO)
    {
      try
      {
        var archivos = _mapper.Map<Turista>(turistaCreacionDTO);

        if (turistaCreacionDTO.Foto != null)
        {
          archivos.Foto = await _almacenadorArchivos.GuardarArchivo(_contenedor, turistaCreacionDTO.Foto);
        }

        _context.Add(archivos);
        await _context.SaveChangesAsync();
        return NoContent();
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("SetTurist", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpPut("[action]/{id:int}")]
    public async Task<ActionResult> ActualizarTurista(Turista turista, int id)
    {
      try
      {
        if (turista.Id != id)
        {
          return BadRequest("El registro no existe");
        }
        var existe = await _context.Turista.AnyAsync(x => x.Id == id);

        if (!existe)
        {
          return NotFound();
        }

        _context.Update(turista);
        await _context.SaveChangesAsync();
        return Ok();
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("UpdateTurist", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpDelete("[action]/{id:int}")]
    public async Task<ActionResult> EliminarTurista([FromRoute] int id)
    {
      try
      {
        var turista = await _context.Turista.FirstOrDefaultAsync(x => x.Id == id);

        if (turista == null)
        {
          return NotFound();
        }
        _context.Remove(turista);
        await _context.SaveChangesAsync();
        return NoContent();
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("DeleteTurist", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }
  }
}
