using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NRWeb.Interfaces.Log;
using TripTravel.Data;
using TripTravel.DTOs;
using TripTravel.Entidades;

namespace TripTravel.Controllers
{
  [ApiController]
  [Route("api/reservahotel")]
  public class ReservaHotelController : Controller
  {
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;
    private readonly ILogService _logService;

    public ReservaHotelController(IMapper mapper, ApplicationDbContext context, ILogService logService)
    {
      this._mapper = mapper;
      this._context = context;
      this._logService = logService;
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<List<ReservaHotelDTO>>> ObtenerReservaHotel()
    {
      try
      {
        return _mapper.Map<List<ReservaHotelDTO>>(await _context.ReservaHotel.ToListAsync());
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("ObtenerReservaHotel", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpGet("[action]/{id:int}")]
    public async Task<ActionResult<ReservaHotelDTO>> ObtenerReservaHotelPorId([FromRoute] int id)
    {
      try
      {
        var reservaHotel = await _context.ReservaHotel.FirstOrDefaultAsync(x => x.Id == id);
        if (reservaHotel == null)
        {
          return NotFound();
        }
        return _mapper.Map<ReservaHotelDTO>(reservaHotel);
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("ObtenerReservaHotelPorId", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpPost("[action]")]
    public async Task<ActionResult> CrearReservaHotel([FromForm] ReservaHotelCreacionDTO reservaHotelCreacionDTO)
    {
      try
      {
        _context.Add(_mapper.Map<ReservaHotel>(reservaHotelCreacionDTO));
        await _context.SaveChangesAsync();
        return NoContent();
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("CrearReservaHotel", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpPut("[action]/{id:int}")]
    public async Task<ActionResult> ActualizarReservaHotel(ReservaHotel reservaHotel, int id)
    {
      try
      {
        if (reservaHotel.Id != id)
        {
          return BadRequest("El registro no existe");
        }
        var existe = await _context.ReservaHotel.AnyAsync(x => x.Id == id);

        if (!existe)
        {
          return NotFound();
        }

        _context.Update(reservaHotel);
        await _context.SaveChangesAsync();
        return Ok();
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("ActualizarReservaHotel", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpDelete("[action]/{id:int}")]
    public async Task<ActionResult> EliminarReservaHotel([FromRoute] int id)
    {
      try
      {
        var reservaHotel = await _context.ReservaHotel.FirstOrDefaultAsync(x => x.Id == id);

        if (reservaHotel == null)
        {
          return NotFound();
        }
        _context.Remove(reservaHotel);
        await _context.SaveChangesAsync();
        return NoContent();
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("EliminarReservaHotel", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }
  }
}
