namespace TeslaCarSharing.Core;

public class Reservation
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public Car Car { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TotalPrice { get; set; }


}