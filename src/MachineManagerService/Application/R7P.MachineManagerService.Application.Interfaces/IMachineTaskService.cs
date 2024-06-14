
using R7P.MachineManagerService.Application.Models;

namespace R7P.MachineManagerService.Application.Interfaces
{
    public interface IMachineTaskService
    {
        Task<Models.MachineTaskDto> GetByIdAsync(long id);
        Task<Models.MachineTaskDto> AddAsync(Models.MachineTaskDto machineTask);
        Task<bool> DeleteAsync(long id);

        Task UpdateAsync(Models.MachineTaskDto machineTask);
        Task<int> GetLastTaskOrderValueAsync(long machineId);
    }
}
