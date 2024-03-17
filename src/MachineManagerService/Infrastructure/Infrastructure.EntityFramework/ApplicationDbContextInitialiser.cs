using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace R7P.MachineManagerService.Infrastructure.EntityFramework;

public class ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context)
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger = logger;
    private readonly ApplicationDbContext _context = context;

    public void Initialise()
    {
        try
        {
            _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }    
}
