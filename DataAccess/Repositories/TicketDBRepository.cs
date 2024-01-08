using Common;

namespace DataAccess.Repositories;

public class TicketDBRepository : ITicketDBRepository
{
    private readonly AirlineDbContext _context;

    public TicketDBRepository(AirlineDbContext context)
    {
        _context = context;
    }

    public void Book(Ticket ticket)
    {

        var existingTicket = _context.Tickets.FirstOrDefault(t => t.FlightIdFK == ticket.FlightIdFK && t.Row == ticket.Row && t.Column == ticket.Column && !t.Cancelled);
        if (existingTicket != null)
        {
            throw new InvalidOperationException("This seat is already booked.");
        }

        _context.Tickets.Add(ticket);
        _context.SaveChanges();
    }

    public void Cancel(Ticket ticket)
    {
        var existingTicket = _context.Tickets.FirstOrDefault(t => t.Id == ticket.Id);
        if (existingTicket == null)
        {
            throw new InvalidOperationException("Ticket not found.");
        }
        
        existingTicket.Cancelled = true;
        _context.SaveChanges();
    }

    public IEnumerable<Ticket> GetTickets(int flightId)
    {
        return _context.Tickets.Where(t => t.FlightIdFK == flightId).ToList();
    }
    
    public Ticket GetTicket(int ticketId)
    {
        return _context.Tickets.FirstOrDefault(t => t.Id == ticketId);
    }
}