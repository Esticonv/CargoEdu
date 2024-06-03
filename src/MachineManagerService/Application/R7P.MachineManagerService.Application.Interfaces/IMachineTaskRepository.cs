using R7P.MachineManagerService.Domain.Entities;

namespace R7P.MachineManagerService.Application.Interfaces
{
    public interface IMachineTaskRepository : IRepository<MachineTask, long>
    {
    }
}
