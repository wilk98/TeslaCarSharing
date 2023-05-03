using TeslaCarSharing.Application.DTOs.Customer;
using TeslaCarSharing.Core;

namespace TeslaCarSharing.Application.DTOs.Reservation;

public class CreateReservationDto
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public CustomerDto Customer { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string StartLocation { get; set; }
    public string EndLocation { get; set; }
}
