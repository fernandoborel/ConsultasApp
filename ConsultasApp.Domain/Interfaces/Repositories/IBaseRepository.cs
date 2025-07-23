namespace ConsultasApp.Domain.Interfaces.Repositories;

/// <summary>
/// Interface para reposittórios.
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface IBaseRepository<TEntity> where TEntity : class
{
    Task AddAsync(TEntity obj);
    Task UpdateAsync(TEntity obj);
    Task DeleteAsync(TEntity obj);
    Task<TEntity> GetById(int id);
    Task<List<TEntity>> GetAllAsync();
}
