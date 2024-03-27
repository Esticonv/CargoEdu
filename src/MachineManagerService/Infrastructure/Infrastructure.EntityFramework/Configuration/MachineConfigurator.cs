using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using R7P.MachineManagerService.Domain.Entities;

namespace R7P.MachineManagerService.Infrastructure.EntityFramework.Configuration
{
    internal class MachineConfigurator : IEntityTypeConfiguration<Machine>
    {
        public void Configure(EntityTypeBuilder<Machine> builder)
        {
            builder.HasMany(c => c.Сargoes).WithOne(m => m.Machine);
            builder.HasMany(t => t.Tasks).WithOne(m => m.Machine).IsRequired();
        }    
    }
}
