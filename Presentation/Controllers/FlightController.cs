using Common;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public class FlightController : Controller
{
    private readonly IFlightDBRepository _flightService;

    public FlightController(IFlightDBRepository flightService)
    {
        _flightService = flightService;
    }

    public IActionResult Details(int id)
    {
        var flight = _flightService.GetFlight(1);
        var viewModel = new FlightViewModel
        {
            Id = flight.Id,
            RetailPrice = flight.WholesalePrice + (flight.CommissionRate * flight.WholesalePrice),
            Seats = flight.Seats.Select(s => new Seat { Row = s.Row, Column = s.Column, IsBooked = s.IsBooked }).ToList()
        };
        return View(viewModel);
    }
}