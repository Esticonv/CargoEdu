using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using R7P.OrderService.Domain.Entities;

namespace R7P.OrderService.Infrastructure.Data.Initialiser;

public class ApplicationDbContextInitializer(ILogger<ApplicationDbContextInitializer> logger, ApplicationDbContext context)
{
    private readonly ILogger<ApplicationDbContextInitializer> _logger = logger;
    private readonly ApplicationDbContext _context = context;

    public async Task InitializeAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initializing the database.");
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
        if (!_context.Customers.Any())
        {
            _context.Customers.Add(new Customer
            {
                Name = "Bender",
                Email = "Bender@planetExpress.ru",
                Phone = "+7-29"
            });

            _context.Customers.Add(new Customer {
                Name = "Fry",
                Email = "Fry@planetExpress.ru",
                Phone = "+6-950-4"
            });

            _context.Customers.Add(new Customer {
                Name = "Leela",
                Email = "Leela@planetExpress.ru",
                Phone = "+3-234"
            });

            await _context.SaveChangesAsync();
        }
    }
}
