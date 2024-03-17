using R7P.MachineManagerService.Application.Models;
using R7P.MachineManagerService.Application.Interfaces;
using R7P.MachineManagerService.Domain.Entities;


namespace R7P.MachineManagerService.Application.Implementations
{
    public class MachineService(IMachineRepository machineRepository) : IMachineService
    {
        private readonly IMachineRepository _machineRepository = machineRepository;

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
    }
}
