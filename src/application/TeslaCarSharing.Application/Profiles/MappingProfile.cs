using TeslaCarSharing.Application.DTOs.Customer;
using TeslaCarSharing.Core;
using AutoMapper;
using TeslaCarSharing.Application.DTOs.Car;
using TeslaCarSharing.Application.DTOs.Reservation;

namespace TeslaCarSharing.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Customer, CustomerDto>();
        CreateMap<Car, CarDto>();
        CreateMap<Reservation, ReservationDto>();
    }
}
