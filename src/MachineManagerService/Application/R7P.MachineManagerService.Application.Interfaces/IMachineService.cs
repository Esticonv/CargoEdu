
using R7P.MachineManagerService.Application.Models;

namespace R7P.MachineManagerService.Application.Interfaces
{
    public interface IMachineService
    {
        Task<Models.MachineDto> GetById(int id);
        Task<List<MachineDto>> GetAll();
        Task<Models.MachineDto> Add(Models.MachineDto machine);
        Task<bool> Delete(int id);
    }
}
