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
        CreateMap<Reservation, CreateReservationDto>();
        CreateMap<CreateReservationDto, Reservation>();
        CreateMap<Reservation, ReservationDto>();
        CreateMap<ReservationDto, Reservation>();
        CreateMap<Car, CarDto>();
        CreateMap<Customer, CustomerDto>();
        CreateMap<CarDto, Car>();
        CreateMap<CustomerDto, Customer>();

    }
}
