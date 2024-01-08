using Common;

namespace DataAccess.Repositories;

public interface ITicketRepository
{
    void Book(Ticket ticket);
    void Cancel(int ticketId);
    List<Ticket> GetTickets();
}