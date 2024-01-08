using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using DataAccess;


public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AirlineDbContext>
{
    

    public AirlineDbContext CreateDbContext(string[] args)
    {
        string projectPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "Presentation");
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(projectPath)
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<AirlineDbContext>();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        builder.UseSqlServer(connectionString);

        return new AirlineDbContext(builder.Options);
    }
}