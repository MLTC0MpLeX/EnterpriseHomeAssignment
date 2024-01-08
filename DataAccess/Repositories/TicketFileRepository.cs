using Common;
using Newtonsoft.Json;

namespace DataAccess.Repositories;

public class TicketFileRepository : ITicketRepository
{
    private const string FilePath = "tickets.json";
    private List<Ticket> _tickets;

    public TicketFileRepository()
    {
        if (File.Exists(FilePath))
        {
            var content = File.ReadAllText(FilePath);
            _tickets = JsonConvert.DeserializeObject<List<Ticket>>(content);
        }
        else
        {
            _tickets = new List<Ticket>();
        }
    }

    public void Book(Ticket ticket)
    {
        _tickets.Add(ticket);
        SaveChanges();
    }

    public void Cancel(int ticketId)
    {
        var ticket = _tickets.FirstOrDefault(t => t.Id == ticketId);
        if (ticket != null)
        {
            _tickets.Remove(ticket);
            SaveChanges();
        }
    }

    public List<Ticket> GetTickets()
    {
        return _tickets;
    }

    private void SaveChanges()
    {
        var content = JsonConvert.SerializeObject(_tickets);
        File.WriteAllText(FilePath, content);
    }
}