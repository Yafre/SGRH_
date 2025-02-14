using System.Linq.Expressions;
using SGRH.Domain.Base;

namespace SGRH.Domain.Repository
{
    public interface IBaseRepository <TEntity> where TEntity : class
    {
        Task<TEntity> GetEntityByIdAsync (int id);
        Task UpdateEntityAsync (TEntity entity);
        Task DeleteEntityAsync (TEntity entity);
        Task SaveEntityAsync (TEntity entity);
        Task<List<TEntity>> GetAllAsync();
        Task<bool> ExistsAsync (Expression<Func<TEntity, bool>> filter);

    }
}
