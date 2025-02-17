using System.Linq.Expressions;

namespace SGRH.Domain.Repository
{
    /// <summary>
    /// Interfaz genérica para operaciones básicas de repositorios.
    /// </summary>
    /// <typeparam name="TEntity">Entidad que será manejada por el repositorio.</typeparam>
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetEntityByIdAsync(int id); // Obtener una entidad por su ID.
        Task UpdateEntityAsync(TEntity entity); // Actualizar una entidad existente.
        Task DeleteEntityAsync(TEntity entity); // Eliminar una entidad.
        Task SaveEntityAsync(TEntity entity); // Guardar una nueva entidad.
        Task<List<TEntity>> GetAllAsync(); // Obtener todas las entidades.
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> filter); // Verificar si una entidad cumple una condición.
    }
}
