namespace Common;

public class Seat
{
    public int Id { get; set; }
    public int Row { get; set; }
    public int Column { get; set; }
    public bool IsBooked { get; set; }
    public int FlightId { get; set; }
    public Flight Flight { get; set; }
}