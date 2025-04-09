using SGHR.Domain.Base;
using SGHR.Domain.Entities;
using SGHR.Domain.Repository;
using SGHR.Model.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGHR.Persistence.Interfaces
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        Task<IEnumerable<ClienteGetModel>> GetAllClientesAsync();
        Task<OperationResult> GetClienteViewByIdAsync(int id);
        Task<OperationResult> GetByEmailAsync(string email);
        Task<OperationResult> DeleteClienteAsync(int id);
        Task<OperationResult> ActivateAsync(int id);
        Task<Cliente?> FindEntityByIdAsync(int id);
    }
}
