using TeslaCarSharing.Core;
using AutoMapper;
using TeslaCarSharing.Application.DTOs.Reservation;

namespace TeslaCarSharing.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateReservationDto, Reservation>();
        CreateMap<Reservation, ReservationDto>();
    }
}
