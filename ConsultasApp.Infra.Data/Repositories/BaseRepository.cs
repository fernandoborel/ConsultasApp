using ConsultasApp.Domain.Interfaces.Repositories;
using ConsultasApp.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ConsultasApp.Infra.Data.Repositories;

/// <summary>
/// Modelo base para repositórios.
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly DataContext _context;

    public BaseRepository(DataContext context)
    {
        _context = context;
    }

    public virtual async Task AddAsync(TEntity obj)
    {
        await _context.Set<TEntity>().AddAsync(obj);
        await _context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(TEntity obj)
    {
        var entity = await _context.Set<TEntity>().FindAsync(obj);

        if (entity != null)
            _context.Set<TEntity>().Remove(obj);
        await _context.SaveChangesAsync();
    }

    public virtual async Task<List<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public virtual async Task<TEntity> GetById(int id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public virtual async Task UpdateAsync(TEntity obj)
    {
        var entity = await _context.Set<TEntity>().FindAsync(obj);
        if (entity != null)
            _context.Set<TEntity>().Update(obj);
        await _context.SaveChangesAsync();
    }
}