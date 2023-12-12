using Common;

namespace DataAccess;

using Microsoft.EntityFrameworkCore;

public class AirlineDbContext : DbContext
{
    public DbSet<Flight> Flights { get; set; }
    public DbSet<Ticket> Tickets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=AirlineDb;Trusted_Connection=True;");
    }
}