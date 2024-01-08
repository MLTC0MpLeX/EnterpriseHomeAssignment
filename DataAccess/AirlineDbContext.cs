using Common;

namespace DataAccess;

using Microsoft.EntityFrameworkCore;

public class AirlineDbContext : DbContext
{
    public AirlineDbContext(DbContextOptions<AirlineDbContext> options)
        : base(options)
    {
    }
    public DbSet<Flight> Flights { get; set; }
    public DbSet<Seat> Seats { get; set; }
    public DbSet<Ticket> Tickets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=airline_db;Trusted_Connection=True;");
    }
}