namespace TeslaCarSharing.Application.DTOs.Car;

public class CarDto
{
    public int Id { get; set; }
    public string RegistrationNumber { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public int Year { get; set; }
    public bool IsAvailable { get; set; }
    public string Location { get; set; }
    public decimal PricePerDay { get; set; }
}
