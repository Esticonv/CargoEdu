using R7P.MachineManagerService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using R7P.MachineManagerService.Application.Interfaces;


namespace R7P.MachineManagerService.Infrastructure.Repository
{
    public class MachineRepository: Repository<Machine, int>, IMachineRepository 
    {
        public MachineRepository(DbContext context): base(context)
        {
        }
    }
}
