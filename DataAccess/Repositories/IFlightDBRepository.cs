using Common;

namespace DataAccess.Repositories;

public interface IFlightDBRepository
{
    Flight GetFlight(int id);
    IEnumerable<Flight> GetFlights();
}