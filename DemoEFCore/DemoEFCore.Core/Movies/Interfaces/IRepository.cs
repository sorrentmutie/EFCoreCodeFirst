namespace DemoEFCore.Core.Movies.Interfaces;

public interface IRepository<TEntity, TKey> where TEntity : 
    class, IEntity<TKey>, new()
{
    IQueryable<TEntity>? Get();
    Task<TEntity?> GetByIdAsync(TKey Id);
    Task CreateAsync(TEntity item);
    Task DeleteAsync(TKey Id);
    Task UpdateAsync(TEntity item);
}
