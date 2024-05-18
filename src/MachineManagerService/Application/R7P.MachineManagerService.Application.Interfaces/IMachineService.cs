
using R7P.MachineManagerService.Application.Models;

namespace R7P.MachineManagerService.Application.Interfaces
{
    public interface IMachineService
    {
        Task<Models.MachineDto> GetByIdAsync(long id);
        Task<List<MachineDto>> GetAllAsync();
        Task<Models.MachineDto> AddAsync(Models.MachineDto machine);
        Task<bool> DeleteAsync(long id);
    }
}
