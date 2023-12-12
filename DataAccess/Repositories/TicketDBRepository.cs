using Common;

namespace DataAccess.Repositories;

public class TicketDBRepository
{
    private readonly AirlineDbContext _context;

    public TicketDBRepository(AirlineDbContext context)
    {
        _context = context;
    }

    public void Book(Ticket ticket)
    {
        // Implement booking logic here
    }

    public void Cancel(Ticket ticket)
    {
        // Implement cancellation logic here
    }

    public IEnumerable<Ticket> GetTickets()
    {
        // Implement retrieval logic here
    }
}