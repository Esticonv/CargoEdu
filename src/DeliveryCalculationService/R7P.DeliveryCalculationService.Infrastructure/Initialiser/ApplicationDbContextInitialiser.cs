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

        if (!_context.DeliverySpecifications.Any())
        {
            _context.DeliverySpecifications.Add(new DeliverySpecification
            {
                DepartureAddressId = 0,
                DestinationAddressId = 1,
                Distance = 1,
            });

            await _context.SaveChangesAsync();
        }
    }
}
