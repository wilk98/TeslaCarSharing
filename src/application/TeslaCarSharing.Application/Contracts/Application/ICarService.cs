using TeslaCarSharing.Core;

namespace TeslaCarSharing.Application.Contracts.Application;

public interface ICarService : IGenericService<Car>
{
    Task<IReadOnlyList<Car>> GetAvailableCarsAsync(DateTime startDate, DateTime endDate);
}
