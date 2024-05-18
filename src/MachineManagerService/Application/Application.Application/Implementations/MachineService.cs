using R7P.MachineManagerService.Application.Models;
using R7P.MachineManagerService.Application.Interfaces;
using R7P.MachineManagerService.Domain.Entities;
using R7P.MachineManagerService.Application.Interfaces.Mapping;


namespace R7P.MachineManagerService.Application.Implementations
{
    public class MachineService(IMachineRepository machineRepository) : IMachineService
    {
        private readonly IMachineRepository _machineRepository = machineRepository;

        public async Task<List<MachineDto>> GetAllAsync()
        {
            var machines= await _machineRepository.GetAllAsync(CancellationToken.None,true);

            var results=new List<MachineDto>();
            
            foreach(var machine in machines) {
                results.Add(MachineMapper.ToDto(machine));
            }
            return results;
        }

        public async Task<MachineDto> GetByIdAsync(long id)
        {
            var machine = await _machineRepository.GetAsync(id)
                ?? throw new InvalidOperationException($"Не найден адрес с идентифкатором {id}");

            return MachineMapper.ToDto(machine);
        }

        public async Task<MachineDto> AddAsync(MachineDto machine)
        {
            var machineEntity = MachineMapper.ToDomain(machine);
            machineEntity.Tasks ??= [new MachineTask()];

            _machineRepository.Add(machineEntity);
            await _machineRepository.SaveChangesAsync();

            return MachineMapper.ToDto(machineEntity);
        }

        /*public async Task<MachineDto> AddTask(MachineDto machine)
        {
            var machineEntity = _machineRepository.Get(machine.Id);

            await _machineRepository.SaveChangesAsync();

            return MachineMapper.ToDto(machineEntity);
        }*/

        public async Task<bool> DeleteAsync(long id)
        {
            bool result=_machineRepository.Delete(id);
            await _machineRepository.SaveChangesAsync();
            return result;
        }
    }
}
