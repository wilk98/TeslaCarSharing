using TeslaCarSharing.Application.Contracts.Application;
using TeslaCarSharing.Core;

namespace TeslaCarSharing.Application.Services;

public class TeslaPricePerDayProvider : IPricePerDayProvider
{
    public decimal GetPricePerDay(TeslaModel model)
    {
        switch (model)
        {
            case TeslaModel.ModelS:
                return 200;
            case TeslaModel.Model3:
                return 150;
            case TeslaModel.ModelX:
                return 250;
            case TeslaModel.ModelY:
                return 180;
            default:
                throw new Exception("Invalid Tesla model");
        }
    }
}
