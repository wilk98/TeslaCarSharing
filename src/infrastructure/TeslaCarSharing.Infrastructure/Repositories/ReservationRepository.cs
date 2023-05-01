using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TeslaCarSharing.Application.Contracts.Infrastructure;
using TeslaCarSharing.Application.DTOs.Reservation;
using TeslaCarSharing.Core;

namespace TeslaCarSharing.Infrastructure.Repositories;

public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
{
    private readonly TeslaCarSharingDbContext _context;
    public ReservationRepository(TeslaCarSharingDbContext context) : base(context)
    {
        _context = context;
    }
    public async Task<IReadOnlyList<int>> GetUnavailableCarIdsAsync(DateTime startDate, DateTime endDate)
    {
        var reservations = await _context.Reservations
            .Where(r => (r.StartDate <= startDate && r.EndDate >= startDate) ||
                        (r.StartDate >= startDate && r.StartDate <= endDate))
            .ToListAsync();

        var carIds = reservations.Select(r => r.CarId).Distinct().ToList();

        return carIds;
    }
}
