namespace TeslaCarSharing.Core;

public class Car
{
    public int Id { get; set; }
    public string RegistrationNumber { get; set; }
    public TeslaModel Model { get; set; }
    public string Color { get; set; }
    public int Year { get; set; }
    public bool IsAvailable { get; set; }
    public Location Location { get; set; }
}

