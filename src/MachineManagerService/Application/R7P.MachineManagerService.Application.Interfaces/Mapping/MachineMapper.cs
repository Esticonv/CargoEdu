using Riok.Mapperly.Abstractions;

namespace R7P.MachineManagerService.Application.Interfaces.Mapping
{
    [Mapper]
    public static partial class MachineMapper
    {
        public static partial Models.MachineDto ToDto(Domain.Entities.Machine machine);
        public static partial Domain.Entities.Machine ToDomain(Models.MachineDto machineDto);
    }
}
