using TeslaCarSharing.Core;

public class Reservation
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public Car Car { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Location StartLocation { get; set; }
    public Location EndLocation { get; set; }
    public decimal TotalPrice { get; set; } 


    public void UpdateTotalPrice(Car car)
    {
        var days = (EndDate - StartDate).Days;
        var pricePerDay = car.PricePerDay;
        TotalPrice = days * pricePerDay;
    }
}
