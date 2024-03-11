using R7P.MachineManagerService.Application.Models;

namespace R7P.MachineManagerService.Application.Interfaces
{
    public interface IMachineService
    {
        Task<MachineDto> GetById(int id);
    }
}
