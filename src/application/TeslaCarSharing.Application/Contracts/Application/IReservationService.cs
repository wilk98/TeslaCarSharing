using TeslaCarSharing.Application.DTOs.Customer;
using TeslaCarSharing.Application.DTOs.Reservation;

namespace TeslaCarSharing.Application.Contracts.Application;

public interface IReservationService
{
    Task<int> AddReservationAsync(CreateReservationDto reservationDto);
    Task<ReservationDto> GetReservationAsync(int reservationId);
    Task<IReadOnlyList<ReservationDto>> GetAllReservationsAsync();
    Task<IReadOnlyList<int>> GetUnavailableCarIdsAsync(DateTime startDate, DateTime endDate);
    Task Update(CreateReservationDto reservationDto);
    Task Delete(int reservationId);
}
