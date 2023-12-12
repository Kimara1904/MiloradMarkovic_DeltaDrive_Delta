using AutoMapper;
using MiloradMarkovic_DeltaDrive_Delta.DTOs;
using MiloradMarkovic_DeltaDrive_Delta.Models;

namespace MiloradMarkovic_DeltaDrive_Delta.Mapper
{
    public class PassengerProfile : Profile
    {
        public PassengerProfile()
        {
            CreateMap<RegisterDTO, Passenger>();
        }
    }
}
