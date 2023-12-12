using AutoMapper;
using MiloradMarkovic_DeltaDrive_Delta.DTOs;
using MiloradMarkovic_DeltaDrive_Delta.Models;

namespace MiloradMarkovic_DeltaDrive_Delta.Mapper
{
    public class RatesProfile : Profile
    {
        public RatesProfile()
        {
            CreateMap<Rate, RatesPreviewDTO>()
                .ForMember(dest => dest.PassengerEmail, opt => opt.MapFrom(dest => dest.Passenger.Email));
            CreateMap<RateVehicleDTO, Rate>();
        }
    }
}
