using TeslaCarSharing.Application.Contracts.Infrastructure;
using TeslaCarSharing.Core;

namespace TeslaCarSharing.Infrastructure.Repositories;

public class CarRepository : GenericRepository<Car>, ICarRepository
{
    public CarRepository(TeslaCarSharingDbContext context) : base(context)
    {
    }

}
