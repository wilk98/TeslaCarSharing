using TeslaCarSharing.Application.Contracts.Application;
using TeslaCarSharing.Application.Contracts.Infrastructure;
using TeslaCarSharing.Core;

namespace TeslaCarSharing.Application.Services;

public class CarService : GenericService<Car>, ICarService
{
    private readonly ICarRepository _repository;

    public CarService(ICarRepository repository) : base(repository)
    {
        _repository = repository;
    }
}
