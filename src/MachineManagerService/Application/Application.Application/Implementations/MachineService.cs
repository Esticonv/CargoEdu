using R7P.MachineManagerService.Application.Models;
using R7P.MachineManagerService.Application.Interfaces;
using R7P.MachineManagerService.Domain.Entities;


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
                results.Add(new MachineDto {
                    Id = machine.Id,
                    Name = machine.Name,
                    VolumeCapacity = machine.VolumeCapacity,
                    WeightCapacity = machine.WeightCapacity,
                    MaxSpeed = machine.MaxSpeed,
                    CostPerDistance = machine.CostPerDistance,
                });
            }
            return results;
        }

        public async Task<MachineDto> GetById(int id)
        {
            var machine = await _machineRepository.GetAsync(id)
                ?? throw new InvalidOperationException($"Не найден адрес с идентифкатором {id}");

            return new MachineDto {
                Id = machine.Id,
                Name = machine.Name,
                VolumeCapacity = machine.VolumeCapacity,
                WeightCapacity = machine.WeightCapacity,
                MaxSpeed = machine.MaxSpeed,
                CostPerDistance = machine.CostPerDistance,
            };
        }

        public async Task<MachineDto> Add(MachineDto machine)
        {
            var machineEntity = new Machine {
                Name = machine.Name,
                VolumeCapacity = machine.VolumeCapacity,
                WeightCapacity = machine.WeightCapacity,
                MaxSpeed = machine.MaxSpeed,
                CostPerDistance = machine.CostPerDistance,
                Tasks = [new MachineTask()]
            };

            _machineRepository.Add(machineEntity);
            await _machineRepository.SaveChangesAsync();

            return GetById(machineEntity.Id).Result;
        }
    }
}
