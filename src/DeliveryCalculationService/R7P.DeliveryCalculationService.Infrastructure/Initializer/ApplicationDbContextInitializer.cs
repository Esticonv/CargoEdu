using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using R7P.DeliveryCalculationService.Domain.Entities;

namespace R7P.DeliveryCalculationService.Infrastructure.Initialiser;

public class ApplicationDbContextInitializer(ILogger<ApplicationDbContextInitializer> logger, ApplicationDbContext context)
{
    private readonly ILogger<ApplicationDbContextInitializer> _logger = logger;
    private readonly ApplicationDbContext _context = context;

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    private async Task TrySeedAsync()
    {
        if (!_context.Segments.Any())
        {
            var planets = new List<Address> {
                new() { AddressInfo = "Меркурий" },
                new() { AddressInfo = "Венера" },
                new() { AddressInfo = "Земля" },
                new() { AddressInfo = "Марс" },
                new() { AddressInfo = "Юпитер" },
                new() { AddressInfo = "Сатурн" },
                new() { AddressInfo = "Уран" },
                new() { AddressInfo = "Нептун" }
            }; 

            foreach (var planet in planets) {
                _context.AddressSpecs.Add(planet);
            }                        

            _context.Segments.Add(new Segment
            {
                DepartureAddress = planets[0],
                DestinationAddress = planets[1],
                Distance = 1,
            });

            _context.Segments.Add(new Segment {
                DepartureAddress = planets[1],
                DestinationAddress = planets[2],
                Distance = 3,
            });

            _context.Segments.Add(new Segment {
                DepartureAddress = planets[2],
                DestinationAddress = planets[3],
                Distance = 5,
            });

            _context.Segments.Add(new Segment {
                DepartureAddress = planets[3],
                DestinationAddress = planets[4],
                Distance = 7,
            });

            _context.Segments.Add(new Segment {
                DepartureAddress = planets[4],
                DestinationAddress = planets[5],
                Distance = 11,
            });

            _context.Segments.Add(new Segment {
                DepartureAddress = planets[5],
                DestinationAddress = planets[6],
                Distance = 13,
            });

            _context.Segments.Add(new Segment {
                DepartureAddress = planets[6],
                DestinationAddress = planets[7],
                Distance = 17,
            });

            await _context.SaveChangesAsync();
        }
    }
}
