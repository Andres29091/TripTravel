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
  [Route("api/hotel")]
  public class HotelController : Controller
  {
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;
    private readonly ILogService _logService;

    public HotelController(IMapper mapper, ApplicationDbContext context, ILogService logService)
    {
      this._mapper = mapper;
      this._context = context;
      this._logService = logService;
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<List<HotelDTO>>> ObtenerHotel()
    {
      try
      {
        return _mapper.Map<List<HotelDTO>>(await _context.Hotel.ToListAsync());
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("ObtenerHotel", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpGet("[action]/{id:int}")]
    public async Task<ActionResult<HotelDTO>> ObtenerHotelPorId([FromRoute] int id)
    {
      try
      {
        var hotel = await _context.Turista.FirstOrDefaultAsync(x => x.Id == id);
        if (hotel == null)
        {
          return NotFound();
        }
        return _mapper.Map<HotelDTO>(hotel);
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("ObtenerHotelPorId", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpPost("[action]")]
    public async Task<ActionResult> CrearHotel([FromForm] HotelCreacionDTO hotelCreacionDTO)
    {
      try
      {
        _context.Add(_mapper.Map<Hotel>(hotelCreacionDTO));
        await _context.SaveChangesAsync();
        return NoContent();
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("CrearHotel", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpPut("[action]/{id:int}")]
    public async Task<ActionResult> ActualizarHotel(Hotel hotel, int id)
    {
      try
      {
        if (hotel.Id != id)
        {
          return BadRequest("El registro no existe");
        }
        var existe = await _context.Hotel.AnyAsync(x => x.Id == id);

        if (!existe)
        {
          return NotFound();
        }

        _context.Update(hotel);
        await _context.SaveChangesAsync();
        return Ok();
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("ActualizarHotel", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpDelete("[action]/{id:int}")]
    public async Task<ActionResult> EliminarHotel([FromRoute] int id)
    {
      try
      {
        var hotel = await _context.Hotel.FirstOrDefaultAsync(x => x.Id == id);

        if (hotel == null)
        {
          return NotFound();
        }
        _context.Remove(hotel);
        await _context.SaveChangesAsync();
        return NoContent();
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("EliminarHotel", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }
  }
}

