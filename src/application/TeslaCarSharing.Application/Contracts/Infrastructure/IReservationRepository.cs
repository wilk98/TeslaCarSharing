using TeslaCarSharing.Core;

namespace TeslaCarSharing.Application.Contracts.Infrastructure;

public interface IReservationRepository : IGenericRepository<Reservation>
{
    Task<IReadOnlyList<int>> GetUnavailableCarIdsAsync(DateTime startDate, DateTime endDate);
}

