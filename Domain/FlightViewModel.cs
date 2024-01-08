namespace Common;

public class FlightViewModel
{
    public int Id { get; set; }
    public string FlightNumber { get; set; }
    public decimal RetailPrice { get; set; }
    public int Rows { get; set; }
    public int Columns { get; set; }
    public List<Seat> Seats { get; set; }
}