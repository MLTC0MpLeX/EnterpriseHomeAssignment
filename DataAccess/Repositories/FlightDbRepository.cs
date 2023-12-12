using Common;

namespace DataAccess.Repositories;

public class FlightDbRepository
{
    private readonly AirlineDbContext _context;

    public FlightDbRepository(AirlineDbContext context)
    {
        _context = context;
    }

    public Flight GetFlight(int id)
    {
        // Implement retrieval logic here
    }

    public IEnumerable<Flight> GetFlights()
    {
        // Implement retrieval logic here
    }
}