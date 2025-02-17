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
        /// <summary>
        /// Obtiene una entidad por su ID.
        /// </summary>
        /// <param name="id">El ID de la entidad</param>
        /// <returns>La entidad encontrada</returns>
        Task<TEntity> GetEntityByIdAsync(int id);

        /// <summary>
        /// Actualiza una entidad existente.
        /// </summary>
        /// <param name="entity">La entidad a actualizar</param>
        /// <returns>Resultado de la operación</returns>
        Task<OperationResult> UpdateEntityAsync(TEntity entity);

        /// <summary>
        /// Guarda una nueva entidad.
        /// </summary>
        /// <param name="entity">La entidad a guardar</param>
        /// <returns>Resultado de la operación</returns>
        Task<OperationResult> SaveEntityAsync(TEntity entity);

        /// <summary>
        /// Obtiene todas las entidades.
        /// </summary>
        /// <returns>Lista de todas las entidades</returns>
        Task<List<TEntity>> GetAllAsync();

        /// <summary>
        /// Obtiene todas las entidades que cumplen con un filtro.
        /// </summary>
        /// <param name="filter">El filtro de búsqueda</param>
        /// <returns>Resultado de la operación</returns>
        Task<OperationResult> GetAllAsync(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// Verifica si existe una entidad que cumpla con un filtro.
        /// </summary>
        /// <param name="filter">El filtro de búsqueda</param>
        /// <returns>True si existe, False de lo contrario</returns>
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> filter);
    }
}
