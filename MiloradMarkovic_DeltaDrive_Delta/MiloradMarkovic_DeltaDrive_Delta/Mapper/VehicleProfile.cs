using AutoMapper;
using MiloradMarkovic_DeltaDrive_Delta.Models;

namespace MiloradMarkovic_DeltaDrive_Delta.Mapper
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<CSVVehicle, Vehicle>()
                .ForMember(dest => dest.DriversFirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.DriversLastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => new Location
                {
                    Latitude = src.Latitude,
                    Longitude = src.Longitude
                }))
                .ForMember(dest => dest.StartPrice, opt => opt.MapFrom(src => double.Parse(src.StartPrice.Replace("EUR", ""))))
                .ForMember(dest => dest.PricePerKM, opt => opt.MapFrom(src => double.Parse(src.PricePerKM.Replace("EUR", ""))));
        }
    }
}
