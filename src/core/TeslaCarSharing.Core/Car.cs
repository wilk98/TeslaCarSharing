namespace TeslaCarSharing.Core;

public class Car
{
    public int Id { get; set; }
    public string RegistrationNumber { get; set; }
    public TeslaModel Model { get; set; }
    public string Color { get; set; }
    public int Year { get; set; }
    public Location Location { get; set; }
    public decimal PricePerDay
    {
        get
        {
            switch (Model)
            {
                case TeslaModel.ModelS:
                    return CarPrices.ModelSPricePerDay;
                case TeslaModel.Model3:
                    return CarPrices.Model3PricePerDay;
                case TeslaModel.ModelX:
                    return CarPrices.ModelXPricePerDay;
                case TeslaModel.ModelY:
                    return CarPrices.ModelYPricePerDay;
                default:
                    throw new Exception("Invalid Tesla model");
            }
        }
    }
}

