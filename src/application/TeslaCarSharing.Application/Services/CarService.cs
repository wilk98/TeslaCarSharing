using System.Linq;
using TeslaCarSharing.Application.Contracts.Application;
using TeslaCarSharing.Application.Contracts.Infrastructure;
using TeslaCarSharing.Core;

namespace TeslaCarSharing.Application.Services;

public class CarService : GenericService<Car>, ICarService
{
    private readonly ICarRepository _carRepository;
    private readonly IReservationService _reservationService;

    public CarService(ICarRepository carRepository, IReservationService reservationService) : base(carRepository)
    {
        _carRepository = carRepository;
        _reservationService = reservationService;
    }
    public async Task<IReadOnlyList<Car>> GetAvailableCarsAsync(DateTime startDate, DateTime endDate)
    {
        var cars = await _carRepository.GetAll();
        var unavailableCarIds = await _reservationService.GetUnavailableCarIdsAsync(startDate, endDate);

        var availableCars = cars.Where(c => !unavailableCarIds.Contains(c.Id));

        return availableCars.ToList();
    }
}
