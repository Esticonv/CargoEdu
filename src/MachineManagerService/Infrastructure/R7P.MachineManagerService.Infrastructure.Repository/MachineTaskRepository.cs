using R7P.MachineManagerService.Domain.Entities;
using R7P.MachineManagerService.Application.Interfaces;
using R7P.MachineManagerService.Infrastructure.EntityFramework;


namespace R7P.MachineManagerService.Infrastructure.Repository
{
    public class MachineTaskRepository : Repository<MachineTask, long>, IMachineTaskRepository 
    {
        public MachineTaskRepository(ApplicationDbContext context): base(context)
        {
        }
    }
}
