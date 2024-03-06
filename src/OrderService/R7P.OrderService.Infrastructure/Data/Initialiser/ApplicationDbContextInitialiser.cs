using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using R7P.OrderService.Domain.Entities;

namespace R7P.OrderService.Infrastructure.Data.Initialiser;

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

        if (!_context.Customers.Any())
        {
            _context.Customers.Add(new Customer
            {
                FirstName = "ADMIN",
                LastName = "ADMIN",
                UserName = "ADMIN",
                Email = "admin@mail.ru",
                Phone = "+7-950-469-99-99"
            });

            await _context.SaveChangesAsync();
        }
    }
}
