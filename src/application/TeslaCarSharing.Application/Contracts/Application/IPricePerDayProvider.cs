using TeslaCarSharing.Core;

namespace TeslaCarSharing.Application.Contracts.Application;

public interface IPricePerDayProvider
{
    decimal GetPricePerDay(TeslaModel model);
}
