namespace Core.Repositories;
public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<TEntity?> GetByIdAsync(params object[] keyValues);

    Task<ICollection<TEntity>> GetAllAsync();

    Task InsertAsync(TEntity entity);

    Task UpdateAsync(TEntity entity);

    Task DeleteAsync(TEntity entity);
}
