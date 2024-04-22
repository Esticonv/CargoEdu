using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using R7P.DeliveryCalculationService.Domain.Entities;

namespace R7P.DeliveryCalculationService.Infrastructure.Initialiser;

public class ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context)
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger = logger;
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
            _context.Segments.Add(new Segment
            {
                DepartureAddress = new Address { AddressInfo="Меркурий"},
                DestinationAddress = new Address { AddressInfo = "Венера"},
                Distance = 1,
            });

            _context.Segments.Add(new Segment {
                DepartureAddress = new Address { AddressInfo = "Венера" },
                DestinationAddress = new Address { AddressInfo = "Земля" },
                Distance = 3,
            });

            _context.Segments.Add(new Segment {
                DepartureAddress = new Address { AddressInfo = "Венера" },
                DestinationAddress = new Address { AddressInfo = "Земля" },
                Distance = 5,
            });

            _context.Segments.Add(new Segment {
                DepartureAddress = new Address { AddressInfo = "Земля" },
                DestinationAddress = new Address { AddressInfo = "Марс" },
                Distance = 7,
            });

            _context.Segments.Add(new Segment {
                DepartureAddress = new Address { AddressInfo = "Марс" },
                DestinationAddress = new Address { AddressInfo = "Юпитер" },
                Distance = 11,
            });

            _context.Segments.Add(new Segment {
                DepartureAddress = new Address { AddressInfo = "Юпитер" },
                DestinationAddress = new Address { AddressInfo = "Сатурн" },
                Distance = 13,
            });

            _context.Segments.Add(new Segment {
                DepartureAddress = new Address { AddressInfo = "Сатурн" },
                DestinationAddress = new Address { AddressInfo = "Уран" },
                Distance = 17,
            });

            _context.Segments.Add(new Segment {
                DepartureAddress = new Address { AddressInfo = "Уран" },
                DestinationAddress = new Address { AddressInfo = "Нептун" },
                Distance = 21,
            });

            await _context.SaveChangesAsync();
        }
    }
}
