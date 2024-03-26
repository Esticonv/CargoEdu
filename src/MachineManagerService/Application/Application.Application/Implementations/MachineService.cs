using R7P.MachineManagerService.Application.Models;
using R7P.MachineManagerService.Application.Interfaces;
using R7P.MachineManagerService.Domain.Entities;
using R7P.MachineManagerService.Application.Interfaces.Mapping;


namespace R7P.MachineManagerService.Application.Implementations
{
    public class MachineService(IMachineRepository machineRepository) : IMachineService
    {
        private readonly IMachineRepository _machineRepository = machineRepository;

        public async Task<IEnumerable<MachineDto>> GetFiveIdle()
        {
            var machines= await _machineRepository.GetAllAsync(CancellationToken.None,true);

            var results=new List<MachineDto>();
            
            foreach(var machine in machines.Take(5)) {
                results.Add(MachineMapper.ToDto(machine));
            }
            return results;
        }

        public async Task<MachineDto> GetById(int id)
        {
            var machine = await _machineRepository.GetAsync(id)
                ?? throw new InvalidOperationException($"Не найден адрес с идентифкатором {id}");

            return MachineMapper.ToDto(machine);
        }

        public async Task<MachineDto> Add(MachineDto machine)
        {
            var machineEntity = MachineMapper.ToDomain(machine);
            machineEntity.Tasks ??= [new MachineTask()];

            _machineRepository.Add(machineEntity);
            await _machineRepository.SaveChangesAsync();

            return GetById(machineEntity.Id).Result;
        }
    }
}
