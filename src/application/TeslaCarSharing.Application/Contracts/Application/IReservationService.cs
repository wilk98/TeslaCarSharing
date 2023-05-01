using System.Collections.Generic;
using System.Threading.Tasks;
using TeslaCarSharing.Application.DTOs.Reservation;
using TeslaCarSharing.Core;

namespace TeslaCarSharing.Application.Contracts.Application;

public interface IReservationService
{
    Task<int> AddReservationAsync(CreateReservationDto reservationDto);
    Task<ReservationDto> GetReservationAsync(int reservationId);
    Task<IReadOnlyList<ReservationDto>> GetAllReservationsAsync();
    Task<IReadOnlyList<int>> GetUnavailableCarIdsAsync(DateTime startDate, DateTime endDate);
}
