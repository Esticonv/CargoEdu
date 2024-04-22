using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using R7P.MachineManagerService.Domain.Entities;

namespace R7P.MachineManagerService.Infrastructure.EntityFramework.Configuration
{
    internal class MachineTaskConfigurator : IEntityTypeConfiguration<MachineTask>
    {
        public void Configure(EntityTypeBuilder<MachineTask> builder)
        {
            builder.HasKey(k => new {
                k.MachineId,
                k.TaskOrder
            });
        }
    }
}
