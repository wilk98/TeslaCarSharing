using TeslaCarSharing.Application.DTOs.Car;

namespace TeslaCarSharing.Application.Contracts.Application;

public interface ICarService 
{
    Task<CarDto> GetCarAsync(int carId);
    Task<IReadOnlyList<CarDto>> GetAllCarsAsync();
    Task<CarDto> Add(CarDto carDto);
    Task Update(CarDto carDto);
    Task Delete(int carId);
    Task<IReadOnlyList<CarDto>> GetAvailableCarsAsync(DateTime startDate, DateTime endDate);
}
