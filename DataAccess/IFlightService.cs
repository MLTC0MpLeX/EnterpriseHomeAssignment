using Common;

namespace DataAccess;

public interface IFlightService
{
    Flight GetFlight(int id);
}