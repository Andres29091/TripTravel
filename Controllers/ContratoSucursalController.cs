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
  [Route("api/contratosucursal")]
  public class ContratoSucursalController : Controller
  {
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;
    private readonly ILogService _logService;

    public ContratoSucursalController(IMapper mapper, ApplicationDbContext context, ILogService logService)
    {
      this._mapper = mapper;
      this._context = context;
      this._logService = logService;
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<List<ContratoSucursalDTO>>> ObtenerContratoSucursal()
    {
      try
      {
        return _mapper.Map<List<ContratoSucursalDTO>>(await _context.ContratoSucursal.ToListAsync());
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("ObtenerContratoSucursal", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpGet("[action]/{id:int}")]
    public async Task<ActionResult<ContratoSucursalDTO>> ObtenerContratoSucursalPorId([FromRoute] int id)
    {
      try
      {
        var contratoSucursal = await _context.ContratoSucursal.FirstOrDefaultAsync(x => x.Id == id);
        if (contratoSucursal == null)
        {
          return NotFound();
        }
        return _mapper.Map<ContratoSucursalDTO>(contratoSucursal);
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("ObtenerContratoSucursalPorId", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpPost("[action]")]
    public async Task<ActionResult> CrearContratoSucursal([FromForm] ContratoSucursalCreacionDTO contratoSucursalCreacionDTO)
    {
      try
      {
        _context.Add(_mapper.Map<ContratoSucursal>(contratoSucursalCreacionDTO));
        await _context.SaveChangesAsync();
        return NoContent();
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("CrearContratoSucursal", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpPut("[action]/{id:int}")]
    public async Task<ActionResult> ActualizarContratoSucursal(ContratoSucursal contratoSucursal, int id)
    {
      try
      {
        if (contratoSucursal.Id != id)
        {
          return BadRequest("El registro no existe");
        }
        var existe = await _context.ContratoSucursal.AnyAsync(x => x.Id == id);

        if (!existe)
        {
          return NotFound();
        }

        _context.Update(contratoSucursal);
        await _context.SaveChangesAsync();
        return Ok();
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("ActualizarContratoSucursal", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpDelete("[action]/{id:int}")]
    public async Task<ActionResult> EliminarContratoSucursal([FromRoute] int id)
    {
      try
      {
        var contratoSucursal = await _context.ContratoSucursal.FirstOrDefaultAsync(x => x.Id == id);

        if (contratoSucursal == null)
        {
          return NotFound();
        }
        _context.Remove(contratoSucursal);
        await _context.SaveChangesAsync();
        return NoContent();
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("EliminarContratoSucursal", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }
  }
}
