using Riok.Mapperly.Abstractions;

namespace R7P.MachineManagerService.Application.Interfaces.Mapping
{
    [Mapper]
    public static partial class MachineTaskMapper
    {
        public static partial Models.MachineTaskDto ToDto(Domain.Entities.MachineTask machine);
        public static partial Domain.Entities.MachineTask ToDomain(Models.MachineTaskDto machineDto);
    }
}
