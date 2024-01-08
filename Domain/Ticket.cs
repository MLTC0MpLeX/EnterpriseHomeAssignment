namespace Common;

public class Ticket
{
    public int Id { get; set; }
    public int Row { get; set; }
    public int Column { get; set; }
    public int FlightIdFK { get; set; }
    public string PassportImagePath { get; set; }
    public decimal PricePaid { get; set; }
    public bool Cancelled { get; set; }

    public Flight Flight { get; set; }
}