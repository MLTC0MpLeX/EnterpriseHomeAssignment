namespace Common;

public class Flight
{
    public int Id { get; set; }
    public int Columns { get; set; }
    public int Rows { get; set; }
    public DateTime DepartureDate { get; set; }
    public DateTime ArrivalDate { get; set; }
    public string CountryFrom { get; set; }
    public string CountryTo { get; set; }
    public ICollection<Seat> Seats { get; set; }
    public int SeatsAvailable
    {
        get
        {
            return Seats.Count(seat => !seat.IsBooked);
        }
    }
    public decimal WholesalePrice { get; set; }
    public decimal CommissionRate { get; set; }
}