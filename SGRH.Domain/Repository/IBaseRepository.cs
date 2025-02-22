using SGRH.Domain.Base;
using System.Linq.Expressions;

namespace SGRH.Domain.Repository
{
    /// <summary>
    /// Interfaz genérica que define las operaciones básicas de un repositorio.
    /// </summary>
    /// <typeparam name="TEntity">Entidad</typeparam>
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetEntityByIdAsync(int id);
        Task<OperationResult> UpdateEntityAsync(TEntity entity);
        Task<OperationResult> SaveEntityAsync(TEntity entity);
        Task<List<TEntity>> GetAllAsync();
        Task<OperationResult> GetAllAsync(Expression<Func<TEntity, bool>> filter);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> filter);
        Task<OperationResult> DeleteEntityAsync(TEntity entity);
    }
}
