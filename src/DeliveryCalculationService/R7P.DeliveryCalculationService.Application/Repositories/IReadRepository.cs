using R7P.DeliveryCalculationService.Domain.Entities;

namespace R7P.DeliveryCalculationService.Application.Repositories;

public interface IReadRepository<T, TPrimaryKey> : IRepository where T : IEntity<TPrimaryKey>
{
    IQueryable<T> GetAll(bool noTracking = false);

    Task<List<T>> GetAllAsync(CancellationToken cancellationToken, bool asNoTracking = false);

    T Get(TPrimaryKey id);

    Task<T> GetAsync(TPrimaryKey id);
}
