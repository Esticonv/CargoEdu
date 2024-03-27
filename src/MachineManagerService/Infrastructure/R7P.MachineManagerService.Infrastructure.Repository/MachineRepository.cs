using R7P.MachineManagerService.Domain.Entities;
using R7P.MachineManagerService.Application.Interfaces;
using R7P.MachineManagerService.Infrastructure.EntityFramework;


namespace R7P.MachineManagerService.Infrastructure.Repository
{
    public class MachineRepository: Repository<Machine, int>, IMachineRepository 
    {
        public MachineRepository(ApplicationDbContext context): base(context)
        {
        }
    }
}
