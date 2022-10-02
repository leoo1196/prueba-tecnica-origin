using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    protected readonly ApplicationContext _context;
    protected readonly DbSet<TEntity> _entities;

    public GenericRepository(ApplicationContext context)
    {
        _context = context;
        _entities = _context.Set<TEntity>();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        _entities.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<TEntity>> GetAllAsync()
    {
        return await _entities.AsNoTracking().ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(params object[] keyValues)
    {
        return await _entities.FindAsync(keyValues);
    }

    public async Task InsertAsync(TEntity entity)
    {
        _entities.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _entities.Update(entity);
        await _context.SaveChangesAsync();
    }
}
