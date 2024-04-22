using R7P.DeliveryCalculationService.Domain.Entities;

namespace R7P.DeliveryCalculationService.Application.Repositories;

public interface IRepository
{
}

public interface IRepository<T, TPrimaryKey> : IReadRepository<T, TPrimaryKey> 
    where T : IEntity<TPrimaryKey>
{
    bool Delete(TPrimaryKey id);

    bool Delete(T entity);

    bool DeleteRange(ICollection<T> entities);

    void Update(T entity);
    T Add(T entity);

    Task<T> AddAsync(T entity);

    void AddRange(List<T> entities);

    Task AddRangeAsync(ICollection<T> entities);

    void SaveChanges();

    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
