using R7P.MachineManagerService.Application.Models;
using R7P.MachineManagerService.Application.Interfaces;
using R7P.MachineManagerService.Domain.Entities;
using R7P.MachineManagerService.Application.Interfaces.Mapping;


namespace R7P.MachineManagerService.Application.Implementations
{
    public class MachineTaskService(IMachineTaskRepository machineTaskRepository) : IMachineTaskService
    {
        private readonly IMachineTaskRepository _machineTaskRepository = machineTaskRepository;

        public async Task<MachineTaskDto> GetByIdAsync(long id)
        {
            var machine = await _machineTaskRepository.GetAsync(id)
                ?? throw new InvalidOperationException($"Не найден адрес с идентифкатором {id}");

            return MachineTaskMapper.ToDto(machine);
        }

        public async Task<MachineTaskDto> AddAsync(MachineTaskDto machineTask)
        {
            var machineTaskEntity = MachineTaskMapper.ToDomain(machineTask);

            await _machineTaskRepository.AddAsync(machineTaskEntity);
            await _machineTaskRepository.SaveChangesAsync();

            return MachineTaskMapper.ToDto(machineTaskEntity);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            bool result= _machineTaskRepository.Delete(id);
            await _machineTaskRepository.SaveChangesAsync();
            return result;
        }
    }
}
