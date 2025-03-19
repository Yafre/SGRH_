using SGHR.Domain.Base;
using SGHR.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGHR.Persistence.Interfaces
{
    public interface IServicioRepository
    {
        Task<IEnumerable<Servicio>> GetAllAsync();
        Task<Servicio?> GetByIdAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<OperationResult> AddAsync(Servicio servicio);
        Task<OperationResult> UpdateAsync(Servicio servicio);
        Task<OperationResult> DeleteAsync(int id);
    }
}
