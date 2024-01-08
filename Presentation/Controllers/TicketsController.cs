using Common;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public class TicketsController : Controller
{
    private readonly IFlightDBRepository _flightRepository;
    private readonly ITicketDBRepository _ticketRepository;

    public TicketsController(IFlightDBRepository flightRepository, ITicketDBRepository ticketRepository)
    {
        _flightRepository = flightRepository;
        _ticketRepository = ticketRepository;
    }

    public IActionResult Index()
    {
        var flights = _flightRepository.GetFlights();
        flights = flights.Where(f => f.SeatsAvailable > 0 && f.DepartureDate > DateTime.Now);
        return View(flights);
    }

    public IActionResult Book(int id)
    {

        var flight = _flightRepository.GetFlight(id);
        if (flight.SeatsAvailable <= 0 || flight.DepartureDate <= DateTime.Now)
        {
            return View("Error");
        }
        
        var ticket = new Ticket { FlightIdFK = id, PricePaid = flight.WholesalePrice * 1.1m};
        _ticketRepository.Book(ticket);
        return View(ticket);
    }

    public IActionResult History()
    {
        var tickets = _ticketRepository.GetTickets(User.Identity.GetHashCode());
        return View(tickets);
    }
    
    private string SavePassportImage(IFormFile passportImage)
    {
        var uploadPath = Path.Combine("uploads");
        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(passportImage.FileName);
        var filePath = Path.Combine(uploadPath, fileName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            passportImage.CopyTo(fileStream);
        }

        return "/uploads/" + fileName;
    }
}