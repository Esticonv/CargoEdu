using R7P.MachineManagerService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace R7P.MachineManagerService.Infrastructure.EntityFramework
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Machine> Machines { get; set; }
        public DbSet<Cargo> Cargoes { get; set; }

        public DbSet<MachineTask> MachineTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Machine>().HasMany(c => c.Сargoes).WithOne(m => m.Machine);

            //modelBuilder.Entity<Machine>().HasMany(t => t.Tasks).WithOne(m => m.Machine).IsRequired();

            //modelBuilder.Entity<MachineTask>().HasKey(k => new { k.MachineId, k.TaskOrder });
        }
    }
}
