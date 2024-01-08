using Common;

namespace DataAccess.Repositories;

public class FlightDBRepository : IFlightDBRepository
{
    private readonly AirlineDbContext _context;

    public FlightDBRepository(AirlineDbContext context)
    {
        _context = context;
    }

    public Flight GetFlight(int id)
    {
        return _context.Flights.FirstOrDefault(f => f.Id == id);
    }

    public IEnumerable<Flight> GetFlights()
    {
        return _context.Flights.ToList();
    }
}