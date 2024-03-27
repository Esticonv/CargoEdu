using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using R7P.MachineManagerService.Domain.Entities;
using System.Net;

namespace R7P.MachineManagerService.Infrastructure.EntityFramework;

public class ApplicationDbContextInitializer(ILogger<ApplicationDbContextInitializer> logger, ApplicationDbContext context)
{
    private readonly ILogger<ApplicationDbContextInitializer> _logger = logger;
    private readonly ApplicationDbContext _context = context;

    public void Initialize()
    {
        try
        {
            _context.Database.Migrate();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public void Seed()
    {
        try {
            if (!_context.Machines.Any()) {          
                
                _context.Machines.Add(new Machine {
                    Name="Slow and cheap machine",
                    CostPerDistance=1,
                    MaxSpeed=1,
                    VolumeCapacity=1,
                    WeightCapacity=1,
                    Tasks = [
                        new MachineTask{                            
                        }
                    ]
                });

                _context.Machines.Add(new Machine {
                    Name = "Fast and expensiee machine",
                    CostPerDistance = 4,
                    MaxSpeed = 2,
                    VolumeCapacity = 2,
                    WeightCapacity = 2,
                    Tasks = [
                        new MachineTask{
                        }
                    ]
                });

                _context.SaveChanges();
            }
        }
        catch (Exception ex){
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }
}
