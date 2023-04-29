using TeslaCarSharing.Application.Contracts.Application;
using TeslaCarSharing.Application.Contracts.Infrastructure;
using TeslaCarSharing.Core;

namespace TeslaCarSharing.Application.Services;

public class ReservationService : GenericService<Reservation>, IReservationService
{
    private readonly IReservationRepository _repository;
    public ReservationService(IReservationRepository repository) : base(repository)
    {
        _repository = repository;
    }
}
