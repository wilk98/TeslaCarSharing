using TeslaCarSharing.Core;
using AutoMapper;
using TeslaCarSharing.Application.DTOs.Reservation;
using TeslaCarSharing.Application.DTOs.Car;
using TeslaCarSharing.Application.DTOs.Customer;

namespace TeslaCarSharing.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateReservationDto, Reservation>();
        CreateMap<Reservation, ReservationDto>();
        CreateMap<Car, CarDto>();
        CreateMap<Customer, CustomerDto>();
        CreateMap<CarDto, Car>();
        CreateMap<CustomerDto, Customer>();

    }
}
