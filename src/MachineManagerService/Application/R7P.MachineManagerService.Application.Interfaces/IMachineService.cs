
namespace R7P.MachineManagerService.Application.Interfaces
{
    public interface IMachineService
    {
        Task<Models.MachineDto> GetById(int id);
    }
}
