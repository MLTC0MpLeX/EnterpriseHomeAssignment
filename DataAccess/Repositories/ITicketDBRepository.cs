using Common;

namespace DataAccess.Repositories;

public interface ITicketDBRepository
{
    void Book(Ticket ticket);
    void Cancel(Ticket ticket);
    IEnumerable<Ticket> GetTickets(int flightId);
    Ticket GetTicket(int ticketId);
}