using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeslaCarSharing.Core;

namespace TeslaCarSharing.Application.DTOs.Reservation;

public class ReservationDto
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public int CustomerId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Location StartLocation { get; set; }
    public Location EndLocation { get; set; }
    public decimal TotalPrice { get; set; }
}
