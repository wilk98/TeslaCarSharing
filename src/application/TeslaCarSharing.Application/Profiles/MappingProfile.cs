using TeslaCarSharing.Core;
using AutoMapper;
using TeslaCarSharing.Application.DTOs.Car;

namespace TeslaCarSharing.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Car, CarDto>();
    }
}
