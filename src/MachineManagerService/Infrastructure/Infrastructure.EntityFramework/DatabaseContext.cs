using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<MachineManagerService.Domain.Entities.Machine> Machines { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            /*modelBuilder.Entity<Course>()
                .HasMany(u => u.Lessons)
                .WithOne(c => c.Course)
                .IsRequired();*/
        }
    }
}
