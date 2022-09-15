using AutoMapper;
using TripTravel.DTOs;
using TripTravel.Entidades;

namespace TripTravel.Helpers
{
  public class AutoMapperProfiles : Profile
  {

    public AutoMapperProfiles()
    {
      CreateMap<Turista, TuristaDTO>().ReverseMap();
      CreateMap<TuristaCreacionDTO, Turista>();
      CreateMap<Vuelo, VueloDTO>().ReverseMap();
      CreateMap<VueloCreacionDTO, Vuelo>();
      CreateMap<Sucursal, SucursalDTO>().ReverseMap();
      CreateMap<SucursalCreacionDTO,Sucursal>();
      CreateMap<ReservaHotel, ReservaHotelDTO>().ReverseMap();
      CreateMap<ReservaHotelCreacionDTO, ReservaHotel>();
      CreateMap<Hotel, HotelDTO>().ReverseMap();
      CreateMap<HotelCreacionDTO, Hotel>();
      CreateMap<ContratoSucursal, ContratoSucursalDTO>().ReverseMap();
      CreateMap<ContratoSucursalCreacionDTO, ContratoSucursal>();
    }
  }
}
