
using R7P.MachineManagerService.Application.Models;

namespace R7P.MachineManagerService.Application.Interfaces
{
    public interface IMachineService
    {

        Task<Models.MachineDto> GetById(int id);
        Task<IEnumerable<MachineDto>> GetFiveIdle();
        Task<Models.MachineDto> Add(Models.MachineDto machine);

    }
}
