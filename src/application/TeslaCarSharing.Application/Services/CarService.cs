using AutoMapper;
using System.Linq;
using TeslaCarSharing.Application.Contracts.Application;
using TeslaCarSharing.Application.Contracts.Infrastructure;
using TeslaCarSharing.Application.DTOs.Car;
using TeslaCarSharing.Application.DTOs.Customer;
using TeslaCarSharing.Core;

namespace TeslaCarSharing.Application.Services;

public class CarService : ICarService
{
    private readonly ICarRepository _repository;
    private readonly IReservationService _reservationService;
    private readonly IMapper _mapper;

    public CarService(ICarRepository repository, IReservationService reservationService, IMapper mapper)
    {
        _repository = repository;
        _reservationService = reservationService;
        _mapper = mapper;
    }
    public async Task<CarDto> Add(CarDto carDto)
    {
        var car = _mapper.Map<Car>(carDto);
        var addedCar = await _repository.Add(car);
        return _mapper.Map<CarDto>(addedCar);
    }

    public async Task Delete(int carId)
    {
        var car = await _repository.Get(carId);
        if (car != null)
        {
            await _repository.Delete(car);
        }
    }

    public async Task<IReadOnlyList<CarDto>> GetAllCarsAsync()
    {
        var cars = await _repository.GetAll();
        return _mapper.Map<IReadOnlyList<CarDto>>(cars);
    }

    public async Task<CarDto> GetCarAsync(int carId)
    {
        var car = await _repository.Get(carId);
        return _mapper.Map<CarDto>(car);
    }

    public async Task Update(CarDto carDto)
    {
        var car = _mapper.Map<Car>(carDto);
        await _repository.Update(car);
    }
    public async Task<IReadOnlyList<CarDto>> GetAvailableCarsAsync(DateTime startDate, DateTime endDate)
    {
        var cars = await _repository.GetAll();
        var unavailableCarIds = await _reservationService.GetUnavailableCarIdsAsync(startDate, endDate);

        var availableCars = cars.Where(c => !unavailableCarIds.Contains(c.Id));

        availableCars.ToList();



        return _mapper.Map<IReadOnlyList<CarDto>>(availableCars);
    }

}
