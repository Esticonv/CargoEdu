using R7P.MachineManagerService.Domain.Entities;

namespace R7P.MachineManagerService.Application.Interfaces
{
    public interface IReadRepository<T, TPrimaryKey> : IRepository where T : IEntity<TPrimaryKey>
    {
        IQueryable<T> GetAll(bool noTracking = false);

        Task<List<T>> GetAllAsync(CancellationToken cancellationToken, bool asNoTracking = false);
              
        T Get(TPrimaryKey id);

        Task<T> GetAsync(TPrimaryKey id);
    }
}