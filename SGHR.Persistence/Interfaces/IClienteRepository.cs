using SGHR.Domain.Entities;
using SGHR.Domain.Repository;
using SGHR.Domain.Base;
using System.Threading.Tasks;

namespace SGHR.Persistence.Interfaces
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        Task<OperationResult> GetByEmailAsync(string email);
    }
}
